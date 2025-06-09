namespace Blog.Domain.Users;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public Post(string title, string content)
    {
        this.Title = title;
        this.Content = content;
    }

    public void Update(string title, string content)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.", nameof(title));
        
        if (string.IsNullOrWhiteSpace(content))
            throw new ArgumentException("Content cannot be empty.", nameof(content));
        
        Title = title;
        Content = content;
    }
}