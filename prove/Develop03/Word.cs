public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public string Text
    {
        get { return _text; }
    }

    public bool IsHidden
    {
        get { return _isHidden; }
        set { _isHidden = value; }
    }
}
