using Blog.Domain.Entities;

namespace Blog.Application.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserByIdAsync(int id);
    Task<User?> GetUserByEmailAsync(string email);
    Task<User> CreateUserAsync(User user);
}