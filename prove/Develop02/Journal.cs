public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public Prompts _promptGenerator = new Prompts();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine(entry._date);
                writer.WriteLine($"Mood: {entry._mood}");
                writer.WriteLine($"Health: {entry._health}");
                writer.WriteLine($"Prompt: {entry._prompt}");
                writer.WriteLine($"Journal: {entry._textEnter}");
                writer.WriteLine();
            }
        }
    }

    public void LoadFromFile(string file) 
    {
        if (File.Exists(file))
        {
            _entries.Clear();
            string[] lines = File.ReadAllLines(file);
            for (int i = 0; i + 5 < lines.Length; i += 6)
            {
                Entry entry = new Entry
                {
                    _date = lines[i],
                    _mood = lines[i + 1].Substring(6), // Remove "Mood: " from file
                    _health = lines[i + 2].Substring(8), // Remove "Health: " from file
                    _prompt = lines[i + 3].Substring(8), // Remove "Prompt: " from file
                    _textEnter = lines[i + 4].Substring(9) // Remove "Journal: " from file
                };
                _entries.Add(entry);
            }            
        }
        else
        {
            Console.WriteLine("Error: File Not Found. Please confirm your file name.");
        }
    }
}
