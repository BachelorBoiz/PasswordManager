using PasswordManager.Core.Models;
using PasswordManager.Domain.IRepositories;
using PasswordManager.Infrastructure.Entities;

namespace PasswordManager.Infrastructure.Repositories;

public class PasswordEntryRepository : IPasswordEntryRepository
{
    private readonly PasswordManagerDbContext _ctx;

    public PasswordEntryRepository(PasswordManagerDbContext ctx)
    {
        _ctx = ctx;
    }

    public PasswordEntry? GetPasswordEntry(string website)
    {
        return _ctx.Passwords
            .Where(entity => entity.Website == website)
            .Select(entity => new PasswordEntry()
            {
                Id = entity.Id,
                Username = entity.Username,
                Password = entity.Password,
                Website = entity.Website
            })
            .FirstOrDefault();
    }

    public List<PasswordEntry> GetAllPasswordEntries()
    {
        return _ctx.Passwords
            .Select(entity => new PasswordEntry()
            {
                Id = entity.Id,
                Username = entity.Username,
                Password = entity.Password,
                Website = entity.Website
            })
            .ToList();
    }

    public PasswordEntry SavePasswordEntry(PasswordEntry entry)
    {
        var entity = new PasswordEntryEntity
        {
            Username = entry.Username,
            Password = entry.Password,
            Website = entry.Website
        };

        _ctx.Passwords.Add(entity);
        _ctx.SaveChanges();

        entry.Id = entity.Id; // Update the entry's ID with the generated ID from the database
        return entry;
    }

    public PasswordEntry UpdatePasswordEntry(PasswordEntry entry)
    {
        var existingEntity = _ctx.Passwords.FirstOrDefault(e => e.Website == entry.Website);

        if (existingEntity != null)
        {
            existingEntity.Username = entry.Username;
            existingEntity.Password = entry.Password;
            _ctx.SaveChanges();
        }

        return entry;
    }

    public PasswordEntry DeletePasswordEntry(string website)
    {
        var entityToDelete = _ctx.Passwords.FirstOrDefault(e => e.Website == website);

        if (entityToDelete != null)
        {
            _ctx.Passwords.Remove(entityToDelete);
            _ctx.SaveChanges();

            return new PasswordEntry
            {
                Id = entityToDelete.Id,
                Username = entityToDelete.Username,
                Password = entityToDelete.Password,
                Website = entityToDelete.Website
            };
        }

        return null;
    }
}