using System;
using System.Collections.Generic;

namespace YouTubeTracker
{
    class Program
    {
        static void Main(string[] args)
        {            
            Video video1 = new Video("The Cat Not In The Hat", "Bruce", 225);
            video1.AddComment(new Comment("Peter", "Interesting video!"));
            video1.AddComment(new Comment("Paul", "I'll never unsee that."));
            video1.AddComment(new Comment("Mary", "Waiting for the green eggs and ham!"));

            Video video2 = new Video("Cruising for Beginners", "Harry", 876);
            video2.AddComment(new Comment("May", "Great information!"));
            video2.AddComment(new Comment("June", "This is very helpful, thank you."));
            video2.AddComment(new Comment("April", "I would love a follow-up video."));

            Video video3 = new Video("Gaming, Gaming, Gaming", "Alex", 399);
            video3.AddComment(new Comment("Paul", "I love gaming videos!"));
            video3.AddComment(new Comment("Richard", "How about more gaming?"));
            video3.AddComment(new Comment("Graham", "Not the gaming I want to see."));

            Video video4 = new Video("School as an Adult", "Tina", 440);
            video4.AddComment(new Comment("Jon", "Too much work and school for my taste."));
            video4.AddComment(new Comment("Alex", "What, no time to play?"));
            video4.AddComment(new Comment("Paul", "You gotta do what you gotta do."));

            Video video5 = new Video("Cooking with Rick", "Rick", 950);
            video5.AddComment(new Comment("Tina", "Too bad I don't like to cook."));
            video5.AddComment(new Comment("Alex", "Best fish I ever had!"));
            video5.AddComment(new Comment("Paul", "Love it, I want to learn more!"));

            Video video6 = new Video("Camping 101", "Rick", 1120);
            video6.AddComment(new Comment("Homer", "Good tips."));
            video6.AddComment(new Comment("Bart", "Looks more like glamping to me :)"));
            video6.AddComment(new Comment("List", "Staying at a hotel is camping to me."));

            Video video7 = new Video("Music from my past", "Barry", 666);
            video7.AddComment(new Comment("Dave", "Oldies but Goodies"));
            video7.AddComment(new Comment("Henry", "Yeah man!  Good Stuff!!"));
            video7.AddComment(new Comment("Lucy", "Too hard for me, where is all the POP music?"));
            
            List<Video> videos = new List<Video> 
            { 
                video1, 
                video2, 
                video3, 
                video4,
                video5,
                video6,
                video7 
            };
            
            foreach (Video video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.Length} seconds");
                Console.WriteLine($"Number of comments: {video.NumberOfComments()}");
                Console.WriteLine("Comments:");
                foreach (Comment comment in video.Comments)
                {
                    Console.WriteLine($"> {comment.Name}: {comment.Text}");
                }
                Console.WriteLine();
            }
        }
    }
}
