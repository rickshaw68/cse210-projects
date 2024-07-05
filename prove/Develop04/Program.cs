using System;

//For my exceed requirements I decided to try and add an audio listening activity where the user listens to nature sounds.  I originally
//started with green noise but then went with nature sounds (birds chirping and creek sounds).  I was able to test this on a windows PC
//but I am unable to test this on a MAC.  I found an example of code that allowed the program to detect if the OS was windows, linux, or MACOS
//but I can't test the linux or MACOS.  If the grader is using a MAC I would appreciate feedback if this worked.
//In order to have my spinner work while the audio was playing, I attempted to use threading to allow both to run at the same time for the
//same duration.

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        
        bool running = true;

        while (running)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Nature Sounds Listening Activity");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
            
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity1 = new BreathingActivity();
                    break;
                case "2":
                    ReflectionActivity reflectionActivity1 = new ReflectionActivity();
                    break;
                case "3":
                    ListingActivity listingActivity1 = new ListingActivity();
                    break;
                case "4":
                    GreenNoiseActivity greenNoiseActivity1 = new GreenNoiseActivity();
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
}