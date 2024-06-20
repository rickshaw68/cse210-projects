public class Entry
{
    public string _date;
    public string _prompt;
    public string _textEnter;
    public string _mood;
    public string _health;

    public void Display()
    {        
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine($"Health: {_health}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Journal: {_textEnter}");
        Console.WriteLine();
    }
}