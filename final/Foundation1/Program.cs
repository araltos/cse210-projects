using System;
using System.Collections.Generic;

public abstract class MediaItem
{
    public string Title { get; set; }
    public string Author { get; set; }
}


public abstract class MediaPlayer
{
    public abstract void Play();
    public abstract void Pause();
    public abstract void Stop();
}
public class YouTubeVideo : MediaItem
{
    public int LengthSeconds { get; set; }
    private List<Comment> comments = new List<Comment>();

    public int NumberOfComments()
    {
        return comments.Count;
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public void DisplayComments()
    {
        foreach (var comment in comments)
        {
            Console.WriteLine($"Comment by {comment.Commenter}: {comment.Text}");
        }
    }
}


public class Comment
{
    public string Commenter { get; set; }
    public string Text { get; set; }
}

class Program
{
    static void Main(string[] args)
    {

        var videos = new List<YouTubeVideo>
        {
            new YouTubeVideo
            {
                Title = "Video 1",
                Author = "Author 1",
                LengthSeconds = 120
            },
            new YouTubeVideo
            {
                Title = "Video 2",
                Author = "Author 2",
                LengthSeconds = 180
            },
            new YouTubeVideo
            {
                Title = "Video 3",
                Author = "Author 3",
                LengthSeconds = 150
            }
        };

   
        videos[0].AddComment(new Comment { Commenter = "User 1", Text = "Great video!" });
        videos[0].AddComment(new Comment { Commenter = "User 2", Text = "Awesome content!" });

        videos[1].AddComment(new Comment { Commenter = "User 3", Text = "Interesting topic." });

        videos[2].AddComment(new Comment { Commenter = "User 4", Text = "Nice work!" });
        videos[2].AddComment(new Comment { Commenter = "User 5", Text = "Keep it up." });

    
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length (seconds): {video.LengthSeconds}");
            Console.WriteLine($"Number of Comments: {video.NumberOfComments()}");
            video.DisplayComments();
            Console.WriteLine();
        }
    }
}
