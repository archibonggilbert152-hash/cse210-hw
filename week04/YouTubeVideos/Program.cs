using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("YouTube Videos Project Running...\n");

        // Create list of videos
        List<Video> videos = new List<Video>();

        // Video 1
        Video v1 = new Video("How to Cook Pasta", "Chef Mike", 420);
        v1.AddComment(new Comment("Alice", "Great recipe!"));
        v1.AddComment(new Comment("John", "Tried it and loved it."));
        v1.AddComment(new Comment("Sarah", "Thanks for sharing!"));
        videos.Add(v1);

        // Video 2
        Video v2 = new Video("Top 10 Programming Tips", "CodeWithSam", 900);
        v2.AddComment(new Comment("DevGuy", "Very helpful!"));
        v2.AddComment(new Comment("Ruth", "Number 4 changed my life."));
        v2.AddComment(new Comment("Leo", "Do more videos like this!"));
        videos.Add(v2);

        // Video 3
        Video v3 = new Video("Beginner Guitar Lesson", "MusicPro", 780);
        v3.AddComment(new Comment("Jade", "This was easy to follow."));
        v3.AddComment(new Comment("Chris", "Awesome teacher!"));
        v3.AddComment(new Comment("Daniel", "I'm learning fast."));
        videos.Add(v3);

        // Display all videos
        foreach (var video in videos)
        {
            video.Display();
        }

        Console.ReadLine(); // keep console open
    }
}

class Video
{
    public string Title { get; }
    public string Author { get; }
    public int DurationSeconds { get; }
    private List<Comment> comments = new List<Comment>();

    public Video(string title, string author, int durationSeconds)
    {
        Title = title;
        Author = author;
        DurationSeconds = durationSeconds;
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public void Display()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Duration (s): {DurationSeconds}");
        Console.WriteLine($"Comments ({comments.Count}):");
        foreach (var c in comments)
        {
            Console.WriteLine($" - {c.Author}: {c.Text}");
        }
        Console.WriteLine();
    }
}

class Comment
{
    public string Author { get; }
    public string Text { get; }

    public Comment(string author, string text)
    {
        Author = author;
        Text = text;
    }
}
