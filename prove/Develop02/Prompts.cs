public class Prompts
{
    public List<string> _prompts = new List<string>();

    private static Random _random = new Random();

    public Prompts()
    {
        _prompts.Add("How is the weather today?");
        _prompts.Add("What are you grateful for?");
        _prompts.Add("What is the best part of your day so far?");
        _prompts.Add("Who has made a positive impact on your day?");
        _prompts.Add("What goals did you have for today?");
    }
    public string GetRandomPrompt()
    {
        int strlst = _random.Next(_prompts.Count);
        return _prompts[strlst];
    }
}