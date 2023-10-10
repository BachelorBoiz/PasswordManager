using Microsoft.EntityFrameworkCore;
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

    public async Task<PasswordEntry?> GetPasswordEntry(string website)
    {
        return await _ctx.Passwords
            .Where(entity => entity.Website == website)
            .Select(entity => new PasswordEntry()
            {
                Id = entity.Id,
                Username = entity.Username,
                Password = entity.Password,
                Website = entity.Website
            })
            .FirstOrDefaultAsync();
    }

    public async Task<List<PasswordEntry>> GetAllPasswordEntries()
    {
        return await _ctx.Passwords
            .Select(entity => new PasswordEntry()
            {
                Id = entity.Id,
                Username = entity.Username,
                Password = entity.Password,
                Website = entity.Website
            })
            .ToListAsync();
    }

    public async Task<PasswordEntry> SavePasswordEntry(PasswordEntry entry)
    {
        var entity = new PasswordEntryEntity
        {
            Username = entry.Username,
            Password = entry.Password,
            Website = entry.Website
        };

        _ctx.Passwords.Add(entity);
        await _ctx.SaveChangesAsync();

        entry.Id = entity.Id; // Update the entry's ID with the generated ID from the database
        return entry;
    }

    public async Task<PasswordEntry> UpdatePasswordEntry(PasswordEntry entry)
    {
        var existingEntity = _ctx.Passwords.FirstOrDefault(e => e.Website == entry.Website);

        if (existingEntity != null)
        {
            existingEntity.Username = entry.Username;
            existingEntity.Password = entry.Password;
            await _ctx.SaveChangesAsync();
        }

        return entry;
    }

    public async Task DeletePasswordEntry(int id)
    {
        var entityToDelete = await _ctx.Passwords.FirstOrDefaultAsync(e => e.Id == id);

        if (entityToDelete != null)
        {
            _ctx.Passwords.Remove(entityToDelete);
            await _ctx.SaveChangesAsync();
        }
    }
}