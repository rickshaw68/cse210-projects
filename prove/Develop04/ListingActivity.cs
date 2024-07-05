using System;
using System.Threading; //used for Thread.Sleep(2000); and CountDown(5); commands

public class ListingActivity : Activity
{
    private List<string> listingPrompts;

    private Random random;


    public ListingActivity()
    {
        listingPrompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?",
        };

        random = new Random();        
        Console.Clear();
        OpeningMessage();
        Console.WriteLine();
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as\nmany things as you can in a certain area.");
        Console.WriteLine();
        PromptForTime();
        CountDown(5);        
        Console.WriteLine("List as many items as you can about the following: ");
        Console.WriteLine();
        Console.WriteLine(GetRandomListingPrompt());
        Console.WriteLine();
        Console.WriteLine("Press 'Enter' to begin");
        Console.ReadLine();        
    
        DoListingActivity();
    }

    private string GetRandomListingPrompt()
    {
        int index = random.Next(listingPrompts.Count);
        return listingPrompts[index];
    }

    public void DoListingActivity()
    {
        int time = GetActivityTime();
        List<string> listingItems = new List<string>();
        Console.WriteLine("Begin listing items and press enter when you are ready\nfor the next list item.  This activity will end when your specified time runs out.");
        DateTime endTime = DateTime.Now.AddSeconds(time);

        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
            {
                listingItems.Add(item);
            }
        }

        Console.Clear();
        Console.WriteLine($"Your time has run out.  You listed {listingItems.Count} items.  Here are all of the items you listed: ");
        Console.WriteLine();
        foreach (var item in listingItems)
        {
            Console.WriteLine("* "+item);
        }
        CompleteMessage(10); // set the delay to 10 seconds to allow user to review and reflect on the list
        Console.WriteLine();        
    }

    
}