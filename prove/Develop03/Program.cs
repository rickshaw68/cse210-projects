using System;

// Program added functionality to add back words to the scripture by pressing space bar which will help the user if they want to 'go back' to help them remember the text.  This meets the exceed requirement to enhance the program to help the user with another way to remember the scripture.  This way they can go back and forth without starting the program over again once all words are hidden, they can just go backwards and add back words to help them remember what the verse(s) are.  If space bar is pressed when no words are hidden, it will display a message that all words are visible.

// I added functionality for the multiple verses to allow the second verse to start on a new line using a line break.  I ensured I was able to handle line breaks on both PC, old and new Mac systems.

class Program
{
    static void Main(string[] args)
    {
        // Create a reference and scripture text
        // having the scripture here allows me to change the scripture at any time and it will still be handled the same by the other classes without having to change them as well.
        string scriptureText = "And God said, Let us make man in our image, after our likeness: and let them have dominion over the fish of the sea, and over the fowl of the air, and over the cattle, and over all the earth, and over every creeping thing that creepeth upon the earth.\n\nSo God created man in his own image, in the image of God created he him; male and female created he them.";
        
        Reference reference = new Reference("Genesis", 1, 26, 27, scriptureText);

        // Creates a Scripture object
        Scripture scripture = new Scripture(reference);

        DisplayScripture(scripture);

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Press 'Enter' to hide words, 'Spacebar' to unhide words, or type 'quit' to exit program");

            // Read key input for Enter and Spacebar
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

            if (keyInfo.Key == ConsoleKey.Enter) // uses the enter key to remove words
            {
                if (scripture.ScriptureHidden())
                {
                    Console.WriteLine("All words are hidden. Exiting the program.");
                    break;
                }
                scripture.HideRandomWords(3); // Modify how many words to hide at a time
                DisplayScripture(scripture);
            }
            else if (keyInfo.Key == ConsoleKey.Spacebar) // uses space bar to unhide until all words visible
            {
                if (scripture.ScriptureVisible())
                {
                    Console.WriteLine("All words are visible.");
                }
                else
                {
                    scripture.UnhideRandomWords(3); // Modify how many words to unhide at a time
                    DisplayScripture(scripture);
                }
            }
            else
            {
                // Handle other key inputs other than 'enter' or 'space bar'
                Console.Write(keyInfo.KeyChar);
                string command = Console.ReadLine()?.ToLower(); // quit the program by typing quit.  handles uppercase.
                command = keyInfo.KeyChar + command;
                if (command == "quit")
                {
                    break;
                }                
            }
        }
    }

    static void DisplayScripture(Scripture scripture)
    {
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
    }
}
