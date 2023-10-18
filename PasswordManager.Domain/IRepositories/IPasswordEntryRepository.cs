using PasswordManager.Core.Models;

namespace PasswordManager.Domain.IRepositories;

public interface IPasswordEntryRepository
{
    Task<PasswordEntry?> GetPasswordEntry(string website);
    Task<List<PasswordEntry>> GetAllPasswordEntries(int userId);
    Task<PasswordEntry> SavePasswordEntry(PasswordEntry entry);
    Task<PasswordEntry> UpdatePasswordEntry(PasswordEntry entry);
    Task DeletePasswordEntry(int id);
}