using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {        
        Running running = new Running("01 Jan 2024", 50, 4.5);
        Cycling cycling = new Cycling("22 Feb 2024", 45, 22.0);
        Swimming swimming = new Swimming("20 Mar 2024", 90, 30);
        
        List<Activity> activities = new List<Activity> { running, cycling, swimming };
        
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
