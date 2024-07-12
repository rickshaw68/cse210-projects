using System;
using System.Collections.Generic;
using System.IO;

// exceeded requirements by doing the following:
// added another menu option to give the ability to remove a completed goal from the list.
// added a text animation when a goal event is recorded
// added a progress bar and % complete for a goal that has been recorded.  For simple goals it will be just 0% and 100% complete,
// but for the checklist goals, it will show the % based on the quantity entered and how many are completed of the quantity.
// for my text file, I chose to delineate between entry fields with a ";" rather than "," in case the user enters a "," when
// typing goal information.
// I also added the infinity symbol (∞) in EternalGoal  by using the unicode \u221E as a better representation of an eternal
// goal that does not get checked as complete like the other goals.

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Goal Menu:");
            Console.WriteLine("1: Create a new goal");
            Console.WriteLine("2: List your goals");
            Console.WriteLine("3: Save your goals to a file");
            Console.WriteLine("4: Load your goals from a file");
            Console.WriteLine("5: Record a goal event");
            Console.WriteLine("6: Remove a completed goal");
            Console.WriteLine("7: Exit Goal Program");            
            Console.Write("Enter your choice > ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalNames();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    RemoveGoal();
                    break;
                case "7":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid Selection, Please Try Again");
                    Console.ReadLine();
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Your Score: {_score}");        
    }

    public void ListGoalNames()
    {
        Console.Clear();
        if (_goals == null || _goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
        }
        else
        {
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {_goals[i].GetDetailsString()}");
            }
        }
        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine();
    }

    public void ListGoalDetails()
    {
        if (_goals == null || _goals.Count == 0)
        {
            Console.WriteLine("No goals available. Try creating one!");
        }
        else
        {
            foreach (var goal in _goals)
            {
                Console.WriteLine(goal.GetDetailsString());
            }
        }
        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine();
    }

    public void CreateGoal()
    {
        Console.Clear();
        Console.WriteLine("What type of goal do you want to set?");
        Console.WriteLine("1: Simple");
        Console.WriteLine("2: Eternal");
        Console.WriteLine("3: Checklist");
        Console.Write("Enter your choice > ");

        string choice = Console.ReadLine();
        Goal goal = null;
        switch (choice)
        {
            case "1":
                Console.WriteLine("Enter goal name:");
                string simpleName = Console.ReadLine();
                Console.WriteLine("Enter goal description:");
                string simpleDescription = Console.ReadLine();
                Console.WriteLine("Enter goal points:");
                int simplePoints = int.Parse(Console.ReadLine());
                goal = new SimpleGoal(simpleName, simpleDescription, simplePoints);
                break;
            case "2":
                Console.WriteLine("Enter goal name:");
                string eternalName = Console.ReadLine();
                Console.WriteLine("Enter goal description:");
                string eternalDescription = Console.ReadLine();
                Console.WriteLine("Enter goal points:");
                int eternalPoints = int.Parse(Console.ReadLine());
                goal = new EternalGoal(eternalName, eternalDescription, eternalPoints);
                break;
            case "3":
                Console.WriteLine("Enter goal name:");
                string checklistName = Console.ReadLine();
                Console.WriteLine("Enter goal description:");
                string checklistDescription = Console.ReadLine();
                Console.WriteLine("Enter goal points:");
                int checklistPoints = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter target amount:");
                int target = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter bonus points:");
                int bonus = int.Parse(Console.ReadLine());
                goal = new ChecklistGoal(checklistName, checklistDescription, checklistPoints, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid Selection, Please Try Again");
                Console.ReadLine(); 
                return;
        }
        _goals.Add(goal);
        Console.WriteLine("Congratulations, you have created a new goal!");
        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine();
    }

    public void RemoveGoal()
    {
        if (_goals == null || _goals.Count == 0)
        {
            Console.WriteLine("You don't have any goals to remove.");
            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
            return;
        }

        Console.Clear();
        Console.WriteLine("Select the goal you wish to remove:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {_goals[i].GetDetailsString()}");
        }

        Console.Write("Enter the number of the goal to remove > ");
        string input = Console.ReadLine();
        int choice;
        if (!int.TryParse(input, out choice) || choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine("Invalid selection, please try again.");
            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
            return;
        }

        _goals.RemoveAt(choice - 1);
        Console.WriteLine("Goal removed successfully.");
        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine();
    }

    public void RecordEvent()
    {
        if (_goals == null || _goals.Count == 0)
        {
            Console.WriteLine("You don't have any goals yet. Try creating one.");
            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
            return;
        }

        Console.Clear();
        Console.WriteLine("Select your goal from the list:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {_goals[i].GetDetailsString()}");
        }

        Console.Write("Select the goal you wish to report on > ");
        string input = Console.ReadLine();
        int choice;
        if (!int.TryParse(input, out choice) || choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine("Invalid selection, please try again.");
            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
            return;
        }

        int points = _goals[choice - 1].RecordEvent();
        _score += points;
        Console.Clear();
        
        DisplayCompletionMessage($"Event recorded. You have earned {points} points!");    
        DisplayProgressBar(_goals[choice - 1]); // display the progress bar and % based on the goal the user chooses

        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine();
    }

    public void SaveGoals()
    {
        Console.WriteLine("Enter the name of the goal file that you want to save: ");
        Console.Write(">");
        string filename = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score); // save the score from the current session
            foreach (var goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals and score saved successfully.");
        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine();
    }

    public void LoadGoals()
{
    Console.WriteLine("Enter the name of your Goal file to load your goals: ");
    Console.Write(">");
    string filename = Console.ReadLine();
    
    if (!File.Exists(filename))
    {
        Console.WriteLine("File not found. Please make sure the file exists and try again.");
        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine();
        return;
    }

    _goals.Clear();
    using (StreamReader reader = new StreamReader(filename))
    {
        string line = reader.ReadLine();
        if (!int.TryParse(line, out _score))
        {
            Console.WriteLine("Invalid file format. Could not load the score.");
            return;
        }
        while ((line = reader.ReadLine()) != null)
        {
            var parts = line.Split(';');
            if (parts.Length < 4)
            {
                Console.WriteLine($"Invalid line format: {line}");
                continue;
            }

            string type = parts[0];
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);
            Goal goal = null;
            try
            {
                switch (type)
                {
                    case "Simple":
                        bool isComplete = bool.Parse(parts[4]);
                        goal = new SimpleGoal(name, description, points);
                        ((SimpleGoal)goal).IsComplete = isComplete;
                        break;
                    case "Eternal":
                        goal = new EternalGoal(name, description, points);
                        break;
                    case "Checklist":
                        int amountCompleted = int.Parse(parts[4]);
                        int target = int.Parse(parts[5]);
                        int bonus = int.Parse(parts[6]);
                        goal = new ChecklistGoal(name, description, points, target, bonus);
                        ((ChecklistGoal)goal).AmountCompleted = amountCompleted;
                        break;
                    default:
                        Console.WriteLine($"Unknown goal type: {type}");
                        continue;
                }
                _goals.Add(goal);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading goal from file: {ex.Message}");
            }
        }
    }
    Console.WriteLine("Goals and score loaded successfully.");
    Console.WriteLine("\nPress Enter to return to the menu...");
    Console.ReadLine();
}

    public void DisplayCompletionMessage(string message) // text animation when a goal event is recorded
    {
        foreach (char c in message)
        {
            Console.Write(c);
            System.Threading.Thread.Sleep(50); // this determines the speed of the text being written to console
        }
        Console.WriteLine();
    }

    public void DisplayProgressBar(Goal goal)
    {
        Console.WriteLine($"Progress for goal: {goal.Name}");

        int progress = 0;
        int barWidth = 50;
        if (goal is ChecklistGoal checklistGoal)
        {
            progress = (int)((double)checklistGoal.AmountCompleted / checklistGoal.Target * 100); // checklist goal is calculated
        }
        else if (goal is SimpleGoal simpleGoal)
        {
            progress = simpleGoal.IsComplete ? 100 : 0; // simple goals are either 0% or 100%
        }
        else if (goal is EternalGoal)
        {
            progress = 0; // Eternal goals are never complete so progress stays at 0%
        }

        Console.Write("["); // progress bar that matches the % complete
        int position = (int)((double)progress / 100 * barWidth);

        for (int i = 0; i < barWidth; ++i)
        {
            if (i < position) Console.Write("=");
            else if (i == position) Console.Write(">");
            else Console.Write(" ");
        }
        Console.Write($"] {progress}% Complete");
        Console.WriteLine();
    }
}
