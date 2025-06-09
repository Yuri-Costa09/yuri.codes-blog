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

    public async Task<User> CreateUserAsync(string name, string email, string password)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty.", nameof(name));
        if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email cannot be empty.", nameof(email));
        if (!email.Contains('@')) throw new ArgumentException("Email must contain at least one '@'.", nameof(email));
        
        if (password.Length < 6) throw new ArgumentException("Password must be at least 6 characters.", nameof(password));

        var user = new User(name, email, password);
        return await _repository.CreateUserAsync(user);
    }
}