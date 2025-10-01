using System.Text;

public class Word
{
    // Private attributes (encapsulation)
    private string _text;
    private bool _isHidden;

    // Constructor
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // Getters / setters
    public string GetText()
    {
        return _text;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    // Behaviors
    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }
    public string Display()
    {
        if (!_isHidden) return _text;

        var sb = new StringBuilder();
        foreach (char c in _text)
        {
            if (char.IsLetter(c))
            {
                sb.Append('_');
            }
            else
            {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }
}
