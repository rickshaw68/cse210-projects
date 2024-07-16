using System;

namespace YouTubeTracker
{
    public class Comment
    {
        public string Name 
        { 
            get; // getter returns the value for Name
            set; // setter sets the value
        }
        public string Text 
        { 
            get; // getter returns the value for Text
            set; // setter sets the value
        }

        public Comment(string name, string text)
        {
            Name = name;
            Text = text;
        }
    }
}
