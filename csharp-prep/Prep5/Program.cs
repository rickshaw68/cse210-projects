using System;

class Program
{
    static void Main(string[] args)
    {
       DisplayWelcome();
       string name = PromptUserName(); 
       int num = PromptUserNumber();
       int sqnum = SquareNumber(num);
       DisplayResult(name, sqnum);
    }
    static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the program!");
        }
    
    static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }

    static int PromptUserNumber()
    {        
        Console.Write("Please enter your favorite number: ");
        int num = int.Parse(Console.ReadLine());
        return num;
    }

   static int SquareNumber(int num)
    {        
        int sqnum = num * num;
        return sqnum;
    }

    static void DisplayResult(string name, int sqnum)
    {
        Console.WriteLine($"{name}, the square root of your number is {sqnum}");
    } 
}