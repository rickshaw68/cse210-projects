using System;
using System.Threading; //used for the Thread.Sleep(1000); command

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        Console.Clear();
        OpeningMessage();
        Console.WriteLine();
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly.\nClear your mind and focus on your breathing.");
        Console.WriteLine();
        PromptForTime();
        CountDown(5);

        Console.WriteLine("Your Breathing Activity Starts NOW");
        Console.WriteLine();
        DoBreathingActivity();
    }

    

    public void DoBreathingActivity()
    {
        int time = GetActivityTime();
        int remainingTime = time;
        while (remainingTime > 0)
        {
            if (remainingTime < 5)
            {
                Console.WriteLine("Breathe In Through Your Nose...");
                BreathCountdown(remainingTime);
                remainingTime = 0;
            }
            else
            {
                Console.WriteLine("Breathe In Through Your Nose...");
                BreathCountdown(5);
                remainingTime -= 5;
                if (remainingTime <= 0) break;

                Console.WriteLine("Breathe Out Through Your Mouth...");
                BreathCountdown(Math.Min(5, remainingTime));
                remainingTime -= Math.Min(5, remainingTime);
            }            
        }
        CompleteMessage();
        Console.WriteLine();
    }

    private void BreathCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine(i);
            Thread.Sleep(1000);
        }
    }
    
}