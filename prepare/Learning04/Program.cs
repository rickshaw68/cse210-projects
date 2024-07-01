using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment("Fred Bread", "Peanut Butter and Jam"); 
        Console.WriteLine(assignment1.GetSummary());

        MathAssignment math1 = new MathAssignment("Joe Blow", "Mathmatics", "Section 7.1", "Problems 3 - 10");
        Console.WriteLine(math1.GetSummary());        
        Console.WriteLine(math1.GetHomeworkList());

        WritingAssignment a1 = new WritingAssignment("Don Juan", "Writing", "The Bird And The Turd");
        Console.WriteLine(a1.GetSummary());
        Console.WriteLine(a1.GetWritingInformation());
    }
}