using System;

class Program
{
    static void Main(string[] args)
    {
        string response;
        do
        {
            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1, 100);


            // Console.Write("What is the magic number? ");
            // string numberText = Console.ReadLine();           

            // int number = int.Parse(numberText);
            int guess = 0; 
            int count = 1;       

            while (guess != number)           
            {   
                Console.Write("What is your guess? ");
                string guessText = Console.ReadLine();
                guess = int.Parse(guessText);
                
                if (guess > number)
                {
                    Console.WriteLine("Lower");
                    count += 1;                               
                }
                else if (guess < number)
                {
                    Console.WriteLine("Higher");
                    count += 1;                 
                }
                else
                {
                    Console.WriteLine($"You guessed the number in {count} tries.");
                }                
            }
            Console.Write("Do you want to continue? ");
            response = Console.ReadLine(); 
        }   while (response == "yes");
        
    }
}