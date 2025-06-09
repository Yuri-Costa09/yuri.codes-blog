using Blog.Application.Interfaces;
using Blog.Domain.Entities;

namespace Blog.Application.Services;

public class UserService
{
    private readonly IUserRepository _repository;
    public UserService(IUserRepository repository) => _repository = repository;
    
    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _repository.GetUserByIdAsync(id);
    }
    
    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _repository.GetUserByEmailAsync(email);
    }
}