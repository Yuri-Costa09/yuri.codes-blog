using Blog.Application.Interfaces;
using Blog.Domain.Entities;

namespace Blog.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    public Task<User?> GetUserByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetUserByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<User> CreateUserAsync(User user)
    {
        throw new NotImplementedException();
    }
}