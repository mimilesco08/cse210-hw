
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // First video
        Video vid1 = new Video("Learn C# Basics", "Code Pinas", 600);
        vid1.AddComment(new Comment("John", "This helped me a lot!"));
        vid1.AddComment(new Comment("Sarah", "Finally understand variables!"));
        vid1.AddComment(new Comment("Kyle", "Nice explanation."));
        videos.Add(vid1);

        // Second video
        Video vid2 = new Video("C# OOP Concepts", "Developer Guys", 720);
        vid2.AddComment(new Comment("Lara", "Very clear examples."));
        vid2.AddComment(new Comment("Ben", "Awesome video!"));
        vid2.AddComment(new Comment("Tina", "Can you do one for inheritance?"));
        videos.Add(vid2);

        // Third video
        Video vid3 = new Video("Understanding Abstraction", "IT Talks", 550);
        vid3.AddComment(new Comment("Paul", "This made abstraction easy!"));
        vid3.AddComment(new Comment("Kate", "Short and simple."));
        vid3.AddComment(new Comment("Leo", "Great for beginners."));
        videos.Add(vid3);

        // Show all video info
        foreach (Video v in videos)
        {
            v.ShowVideoInfo();
        }
    }
    
}
