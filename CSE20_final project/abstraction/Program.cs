using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        var video1 = new Video("Video Title 1", "Author 1", 300);
        video1.AddComment(new Comment("User1", "Great video!"));
        video1.AddComment(new Comment("User2", "Very informative."));

        var video2 = new Video("Video Title 2", "Author 2", 200);
        video2.AddComment(new Comment("User3", "Nice work!"));

        var video3 = new Video("Video Title 3", "Author 3", 400);
        video3.AddComment(new Comment("User4", "Loved it!"));
        video3.AddComment(new Comment("User5", "Awesome content."));

        // List of videos
        var videos = new List<Video> { video1, video2, video3 };

        // Display video information
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}, Author: {video.Author}, Length: {video.Length} seconds, Comments: {video.GetCommentCount()}");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"  - {comment.Author}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}

class Video
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int Length { get; private set; }
    public List<Comment> Comments { get; private set; }

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

    public int GetCommentCount()
    {
        return Comments.Count;
    }
}

class Comment
{
    public string Author { get; private set; }
    public string Text { get; private set; }

    public Comment(string author, string text)
    {
        Author = author;
        Text = text;
    }
}
