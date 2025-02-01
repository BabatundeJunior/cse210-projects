using System;
using System.Collections.Generic;

// Comment class to store commenter name and text
class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

// Video class to store video details and comments
class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // in seconds
    private List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(string commenterName, string text)
    {
        Comments.Add(new Comment(commenterName, text));
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}\nAuthor: {Author}\nLength: {Length} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");
        foreach (var comment in Comments)
        {
            Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
        }
        Console.WriteLine("--------------------------------------");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        List<Video> videos = new List<Video>();

        // Creating videos
        Video video1 = new Video("Hp Envy 360 Review", "John Doe", 300);
        video1.AddComment("Alice", "Is this a great laptop for programming?");
        video1.AddComment("Bob", "Can a graphic designer use this?");
        video1.AddComment("Charlie", "Thanks for the review was contemplating a new laptop to buy.");

        Video video2 = new Video("Apple Iphone 14 Review", "Calton Smith", 450);
        video2.AddComment("David", "I want upgrade my iphone 11 to 14.");
        video2.AddComment("Emma", "Can I still buy the Iphone 14 in 2025?");
        video2.AddComment("Frank", "Please do a review for the iphone 16 and the 15.");

        Video video3 = new Video("The Future of AI", "Mike Johnson", 600);
        video3.AddComment("George", "I Love your company's tech videos.");
        video3.AddComment("Hannah", "Great AI is taking over humanity.");
        video3.AddComment("Ian", "Is AI going to take our Jobs?");

        // Adding videos to the list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Displaying video information
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
