using System;
using System.Threading; //used for Thread.Sleep(250); and CountDown(3); commands

public class ReflectionActivity : Activity
{
    private List<string> reflectionPrompts;
    private List<string> reflectQuestions;
    private Random random;
    public ReflectionActivity()
    {
        reflectionPrompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        reflectQuestions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        random = new Random();
        Console.Clear();
        OpeningMessage();
        Console.WriteLine();
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience.\nThis will help you recognize the power you have and how you can use it in other aspects of your life.");
        Console.WriteLine();
        PromptForTime();
        CountDown(3); 
        Console.WriteLine(GetRandomReflectionPrompt());
        ShowSpinner(6);
        DoReflectionActivity();  
    }

    private string GetRandomReflectionPrompt()
    {
        int index = random.Next(reflectionPrompts.Count);
        return reflectionPrompts[index];
    }

    private string GetRandomReflectionQuestion()
    {
        int index = random.Next(reflectQuestions.Count);
        return reflectQuestions[index];
    }
    public void DoReflectionActivity()
    {
        int time = GetActivityTime();
        Console.WriteLine();
        int remainingTime = time;
        
        while (remainingTime > 0)
        {
            Console.Clear();
            Console.WriteLine(GetRandomReflectionQuestion()); 
            Console.WriteLine();            
            int reflectionTime = Math.Min(10, remainingTime);
            ShowSpinner(reflectionTime);
            remainingTime -= reflectionTime;                                               
        }
        CompleteMessage(5);
        Console.WriteLine();
    }
    //private void ReflectCountdown(int seconds)
    //{
    //    for (int i = seconds; i > 0; i--)
    //    {
    //        Console.Clear();
    //        Console.WriteLine($"Reflecting... {i} seconds remaining");
    //        Thread.Sleep(1000);
    //    }
    //}

    
}