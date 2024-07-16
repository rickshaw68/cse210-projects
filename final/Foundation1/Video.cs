using System;
using System.Collections.Generic;

namespace YouTubeTracker
{
    public class Video
    {
        public string Title 
        { 
            get; // getter returns the value for Title
            set; // setter sets the value 
        }
        public string Author 
        { 
            get; // getter returns the value for Author
            set; // setter sets the value 
        }
        public int Length 
        { 
            get; // getter returns the value for Length
            set; // setter sets the value 
        }
        public List<Comment> Comments 
        { 
            get; // getter returns the value for Comments
            set; // setter sets the value 
        }

        public Video(string title, string author, int length)
        {
            Title = title;
            Author = author;
            Length = length;
            Comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public int NumberOfComments()
        {
            return Comments.Count;
        }
    }
}
