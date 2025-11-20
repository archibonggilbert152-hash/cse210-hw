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
    public int Duration { get; } // duration in seconds
    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int duration)
    {
        Title = title;
        Author = author;
        Duration = duration;
    }

    public void AddComment(Comment comment)
    {
        if (comment != null)
        {
            _comments.Add(comment);
        }
    }

    public void Display()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Duration: {FormatDuration(Duration)}");
        Console.WriteLine($"Comments ({_comments.Count}):");
        foreach (var c in _comments)
        {
            Console.WriteLine($"- {c.Author}: {c.Text}");
        }
        Console.WriteLine();
    }

    private string FormatDuration(int seconds)
    {
        int mins = seconds / 60;
        int secs = seconds % 60;
        return $"{mins}:{secs:D2}";
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

    public override string ToString()
    {
        return $"{Author}: {Text}";
    }
}
