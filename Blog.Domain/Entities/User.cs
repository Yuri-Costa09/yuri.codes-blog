namespace Blog.Domain.Entities;

public class User
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string Role { get; private set; } 
    
    public User(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }

    void ChangeEmail(string newEmail)
    {
        if (string.IsNullOrWhiteSpace(newEmail)) 
            throw new ArgumentException("Email cannot be empty.", nameof(newEmail));
        
        if (!newEmail.Contains("@")) 
            throw new ArgumentException("Email must contain at least one '@'.");
        
        this.Email = newEmail;
    }
}