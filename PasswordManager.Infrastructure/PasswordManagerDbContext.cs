using Microsoft.EntityFrameworkCore;
using PasswordManager.Infrastructure.Entities;

namespace PasswordManager.Infrastructure;

public class PasswordManagerDbContext : DbContext
{
    public DbSet<PasswordEntryEntity> Passwords { get; set; }
    
    public PasswordManagerDbContext(DbContextOptions<PasswordManagerDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PasswordEntryEntity>().HasData(new PasswordEntryEntity
        {
            Id = 1,
            Username = "Bob Bobsen",
            Password = "test1234",
            Website = "Facebook",
        });
    }
}