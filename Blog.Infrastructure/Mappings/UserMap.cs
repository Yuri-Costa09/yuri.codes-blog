using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("tb_Users");
        
        builder.HasKey(u => u.Id);
        
        builder.Property(u => u.Id)
            .HasColumnName("Id")
            .IsRequired()
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(u => u.Name)
            .HasColumnName("Name")
            .IsRequired()
            .HasMaxLength(80);
        
        builder.Property(u => u.Email)
            .HasColumnName("Email")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Password)
            .HasColumnName("Password")
            .IsRequired();
        
        builder.Property(u => u.Role)
            .HasColumnName("Role")
            .IsRequired()
            .HasDefaultValue("User");
        
        builder.HasIndex(u => u.Id, "IX_User_Id")
            .IsUnique();
            
    }
}