using Microsoft.EntityFrameworkCore;
using PasswordManager.Core.Models;
using PasswordManager.Infrastructure.Entities;

namespace PasswordManager.Infrastructure;

public class PasswordManagerDbContext : DbContext
{
    public DbSet<PasswordEntryEntity> Passwords { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    
    public PasswordManagerDbContext(DbContextOptions<PasswordManagerDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PasswordEntryEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<UserEntity>().HasKey(x => x.Id);

        modelBuilder.Entity<UserEntity>()
            .HasMany(x => x.Passwords)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .HasPrincipalKey(x => x.Id);

        //modelBuilder.Entity<UserEntity>().HasData(new UserEntity
        //{
        //    Id = 1,
        //    Email = "test@mail.com",
        //    HashedPassword = "123456"
        //});

        //modelBuilder.Entity<PasswordEntryEntity>().HasData(new PasswordEntryEntity
        //{
        //    Id = 1,
        //    UserId = 1,
        //    Password = "123456",
        //    Username = "test",
        //    Website = "test"
        //});
    }
}