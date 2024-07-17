using System;

class Program
{
    static void Main(string[] args)
    {        
        Address address1 = new Address("1428 Elm Street", "Springwood", "OH", "USA");
        Address address2 = new Address("121 Mill Neck", "Long Island", "NY", "USA");
        Address address3 = new Address("4 Privet Drive", "Little Whinging", "Surrey", "England");
        
        Lecture lecture = new Lecture("Your Dreams", "How To Manipulate Your Dreams", "2024-10-31", "12:00 AM", address1, "Freddy Krueger", 230);
        Reception reception = new Reception("Networking Event", "Meet and greet with industry professionals", "2024-09-02", "6:00 PM", address2, "rsvp@johnwick.com");
        OutdoorGathering outdoorGathering = new OutdoorGathering("Hosting A Gathering", "A Back Yard BBQ and Quidditch match for Friends And Family", "2024-09-03", "11:00 AM", address3, "Sunny, Sunny, and more Sun");
        
        DisplayEventDetails(lecture);
        DisplayEventDetails(reception);
        DisplayEventDetails(outdoorGathering);
    }

    static void DisplayEventDetails(Event eventInstance)
    {
        Console.WriteLine("Standard Details:");
        Console.WriteLine(eventInstance.StandardDetails());
        Console.WriteLine();
        
        Console.WriteLine("Full Details:");
        Console.WriteLine(eventInstance.FullDetails());
        Console.WriteLine();
        
        Console.WriteLine("Short Description:");
        Console.WriteLine(eventInstance.ShortDescription());
        Console.WriteLine();
    }
}
