using Blog.Application.Interfaces;
using Blog.Domain.Users;

namespace Blog.Application.Services;

public class PostService
{
    private readonly IPostRepository _repository;
    public PostService(IPostRepository repository) => _repository = repository;
    
    public async Task<Post?> GetAllPostsAsync()
    {
        return await _repository.GetAllPostsAsync();
    }
    
    public async Task<Post?> GetPostByIdAsync(int id)
    {
        return await _repository.GetPostByIdAsync(id);
    }
    
    public async Task<Post> CreatePostAsync(string title, string content)
    {
        if(string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title cannot be empty.", nameof(title));
        if(string.IsNullOrWhiteSpace(content)) throw new ArgumentException("Content cannot be empty.", nameof(content));
        if(title.Length > 200) throw new ArgumentException("Title cannot be longer than 200 characters.", nameof(title));

        var post = new Post( title, content);
        await _repository.CreatePostAsync(post);
        
        return post;
    }

    public async Task<Post> UpdatePostAsync(int id, string title, string content)
    {
        var post = await _repository.GetPostByIdAsync(id) ?? throw new KeyNotFoundException("Post not found.");
        if(string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title cannot be empty.", nameof(title));
        if(string.IsNullOrWhiteSpace(content)) throw new ArgumentException("Content cannot be empty.", nameof(content));
        if(title.Length > 200) throw new ArgumentException("Title cannot be longer than 200 characters.", nameof(title));
        
        post.Update(title, content);
        return await _repository.UpdatePostAsync(post);
    }
}