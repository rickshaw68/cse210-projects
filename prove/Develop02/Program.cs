using System;

// Added two additional journal entry prompts for mood and health in the Prompts class
// Added a check when loading journal file and returns an error if the file name is incorrect or not found
// Added a check with the menu portion to provide an error message if a number that is not part of the
//  menu is selected
// I used the automatic date stamp in C# rather than manually entering it as a string
// In the journal class I added line headers to the screen print so I know what question I was answering i.e. Mood: "<answer>"
// I added functionality to remove the line headers when saving the file
// I added the line headers in the entry.cs class as well.
// I received help on how to add a date stamp using resources on the WEB such as Stack Overflow
// I used resources in wellsb.com and Stack Overflow to learn how to write the console menu 

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display Journal");
            Console.WriteLine("3. Load File");
            Console.WriteLine("4. Save File");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteEntry(myJournal);
                    break;
                case "2":
                    myJournal.DisplayAll();
                    break;
                case "3":
                    LoadJournalFromFile(myJournal);
                    break;
                case "4":
                    SaveJournalToFile(myJournal);
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }

    static void WriteEntry(Journal journal)
    {
        string prompt = journal._promptGenerator.GetRandomPrompt();
        Console.Write("How is your mood today? ");
        string mood = Console.ReadLine();
        Console.Write("How is your health today? ");
        string health = Console.ReadLine();
        Console.WriteLine($"Prompt: {prompt}");        
        Console.Write("Enter your response: ");
        string response = Console.ReadLine();

        Entry newEntry = new Entry
        {
            _date = DateTime.Now.ToString("yyyy-MM-dd"),
            _mood = mood,
            _health = health,
            _prompt = prompt,
            _textEnter = response
        };

        journal.AddEntry(newEntry);
    }

    static void LoadJournalFromFile(Journal journal)
    {
        Console.Write("Enter the file name to load: ");
        string fileName = Console.ReadLine();
        journal.LoadFromFile(fileName);
    }

    static void SaveJournalToFile(Journal journal)
    {
        Console.Write("Enter the file name to save: ");
        string fileName = Console.ReadLine();
        journal.SaveToFile(fileName);
        Console.WriteLine("Entries saved to file.");
    }
}
