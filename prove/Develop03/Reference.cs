public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;
    private string[] _scriptureTexts;

    public Reference(string book, int chapter, int verse, string scriptureText)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = verse;
        _scriptureTexts = new[] { scriptureText };
    }

    public Reference(string book, int chapter, int verse, int endVerse, string scriptureText)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
        _scriptureTexts = scriptureText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None); //new line command for PC and old Mac and new Mac
    }

    public string GetDisplayText()
    {
        if (_verse == _endVerse)
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }

    public string[] GetScriptureTexts()
    {
        return _scriptureTexts;
    }
}
