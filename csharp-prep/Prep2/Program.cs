using System;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string gradePercentage = Console.ReadLine();
        int percentage = int.Parse(gradePercentage);

        string grade = "";
        string sign = "";

        if (percentage >= 90)
        {
            grade = "A";
        }
        else if (percentage >= 80)
        {
            grade = "B";
        }
        else if (percentage >= 70)
        {
            grade = "C";
        }
        else if (percentage >= 60)
        {
            grade = "D";
        }
        else
        {
            grade = "F";            
        }

        if (percentage >= 97 || percentage < 70)
        {
            sign = "";
        }
        else if (percentage % 10 >= 7)
        {
            sign = "+";
        }
        else if (percentage % 10 <= 3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }

        Console.WriteLine($"Your Grade is {grade}{sign}");
        
        
        // Console.Write("What is your grade percentage? ");
        // string gradePercentage = Console.ReadLine();
        // int percentage = int.Parse(gradePercentage);

        // if (percentage >= 90)
        // {
        //     Console.WriteLine("Your grade is 'A'!");
        //     Console.WriteLine("Congratulations!  You Passed The Class");
        // }
        // else if (percentage >= 80)
        // {
        //     Console.WriteLine("Your grade is 'B'");
        //     Console.WriteLine("Congratulations!  You Passed The Class");
        // }
        // else if (percentage >= 70)
        // {
        //     Console.WriteLine("Your grade is 'C'");
        //     Console.WriteLine("Congratulations!  You Passed The Class");
        // }
        // else if (percentage >= 60)
        // {
        //     Console.WriteLine("Your grade is 'D'");
        //     Console.WriteLine("You did not pass the class.  Try again, Don't give up.");
        // }
        // else
        // {
        //     Console.WriteLine("Your grade is 'F'");
            
        // }
    }
}