using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int numInput = -1;

        while (numInput != 0)
        {    
            Console.Write("Please enter a number, or 0 to quit: ");
            string numberText = Console.ReadLine();
            numInput = int.Parse(numberText);        
            
            if (numInput != 0)
            {
                numbers.Add(numInput);
            }           
              
        }
        Console.WriteLine("Your numbers are:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
        
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }
        Console.WriteLine($"The sum of your numbers is {sum}");

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average of your numbers is {average}");

        int largest = numbers[0];
        foreach (int num in numbers)
        {            
            if (num > largest)
            {
                largest = num;
            }        
        }
        Console.WriteLine($"The largest nuber is {largest}");

        int smallest = int.MaxValue;
        foreach (int n in numbers)
        {
           if (n > 0 && n < smallest)
           {
                smallest = n;
           } 
        }
        Console.WriteLine($"The smallest positive number is {smallest}");

        numbers.Sort();
        Console.WriteLine("The sorted nuber list is: ");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}