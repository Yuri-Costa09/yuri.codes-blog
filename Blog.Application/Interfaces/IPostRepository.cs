using Blog.Domain.Users;

namespace Blog.Application.Interfaces;

public interface IPostRepository
{
    Task<List<Post>> GetAllPostsAsync();
    Task<Post> GetPostByIdAsync(int id);
    Task<Post> CreatePostAsync(Post post);
    Task<Post> UpdatePostAsync(Post post);
    Task<bool> DeletePostAsync(int id);
}