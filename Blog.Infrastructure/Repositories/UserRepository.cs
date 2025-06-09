using Blog.Application.Interfaces;
using Blog.Domain.Entities;
using Blog.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly MyDbContext _context;
    
    public UserRepository(MyDbContext context)
    {
        _context = context;
    }
    
    public async Task<User?> GetUserByIdAsync(int id)
    { 
        var user = _context.Users.FindAsync(id);
        return await user;
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        var user = _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        return await user;
    }

    public async Task<User> CreateUserAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }
}