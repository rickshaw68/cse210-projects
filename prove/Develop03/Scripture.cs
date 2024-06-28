using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<List<Word>> _verses;

    public Scripture(Reference reference)
    {
        _reference = reference;
        _verses = new List<List<Word>>();

        string[] versesArray = _reference.GetScriptureTexts();
        foreach (string verse in versesArray)
        {
            List<Word> words = new List<Word>();
            string[] wordsArray = verse.Split(' ');
            foreach (string word in wordsArray)
            {
                words.Add(new Word(word));
            }
            _verses.Add(words);
        }
    }

    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + Environment.NewLine;

        foreach (List<Word> verse in _verses)
        {
            foreach (Word word in verse)
            {
                if (word.IsHidden)
                {
                    displayText += "___ ";
                }
                else
                {
                    displayText += word.Text + " ";
                }
            }
            displayText = displayText.Trim() + Environment.NewLine;
        }

        return displayText.Trim();
    }

    public void HideRandomWords(int count)
    {
        Random random = new Random();
        int hiddenWords = 0;

        while (hiddenWords < count && !ScriptureHidden())
        {
            int verseIndex = random.Next(_verses.Count);
            int wordIndex = random.Next(_verses[verseIndex].Count);
            if (!_verses[verseIndex][wordIndex].IsHidden)
            {
                _verses[verseIndex][wordIndex].IsHidden = true;
                hiddenWords++;
            }
        }
    }

    public void UnhideRandomWords(int count)
    {
        Random random = new Random();
        int unhiddenWords = 0;

        while (unhiddenWords < count && !ScriptureVisible())
        {
            int verseIndex = random.Next(_verses.Count);
            int wordIndex = random.Next(_verses[verseIndex].Count);
            if (_verses[verseIndex][wordIndex].IsHidden)
            {
                _verses[verseIndex][wordIndex].IsHidden = false;
                unhiddenWords++;
            }
        }
    }

    public bool ScriptureHidden()
    {
        foreach (List<Word> verse in _verses)
        {
            foreach (Word word in verse)
            {
                if (!word.IsHidden)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public bool ScriptureVisible()
    {
        foreach (List<Word> verse in _verses)
        {
            foreach (Word word in verse)
            {
                if (word.IsHidden)
                {
                    return false;
                }
            }
        }
        return true;
    }
}
