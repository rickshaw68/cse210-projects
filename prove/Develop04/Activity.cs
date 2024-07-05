using System;
using System.Threading; //Used for the Thread.Sleep(1000); command

public class Activity
{
    private int _time;

    public void OpeningMessage()
    {
        Console.WriteLine("Welcome to the Mindfulness Activity application.");
    }
    
    public void PromptForTime()
    {
        Console.Write("How long do you want to do this activity?  Enter a number in seconds: ");
        
        string input = Console.ReadLine();
        if (int.TryParse(input, out _time))
        {
            Console.WriteLine($"You have chosen to do the activity for {_time} seconds");            
        }
        else
        {
            Console.WriteLine("Invalid input, please enter a valid number in seconds: ");
            PromptForTime();
        }
    }
    
    public int GetActivityTime()
    {        
        return _time;
    }

    public void CompleteMessage(int delaySeconds = 5)
    {
        Console.WriteLine("Congratulations, you have completed the activity.");
        ShowSpinner(delaySeconds);
        Console.Clear();
    }

    public void CountDown(int seconds)
    {
        while (seconds > 0)
        {
            Console.Clear();
            Console.WriteLine($"This activity will start in {seconds} seconds");
            Thread.Sleep(1000);
            seconds--; 
        }
        Console.Clear();
    }
    public void ShowSpinner(int seconds)
    {
        var spinnerChars = new[] {'|', '/', '-', '\\' };
        int spinnerIndex = 0;
        
        for (int i = 0; i < seconds * 4; i++) 
        {
            Console.Write(spinnerChars[spinnerIndex]);
            Thread.Sleep(250);
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            spinnerIndex = (spinnerIndex + 1) % 4;
        }
        Console.Clear();
    }
}