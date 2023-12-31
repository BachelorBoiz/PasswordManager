using PasswordManager.Core.Models;

namespace PasswordManager.Core.IServices;

public interface IPasswordEntryService
{
    Task<PasswordEntry> AddPasswordEntry(PasswordEntry entry);
    Task<PasswordEntry?> GetPasswordEntry(string website);
    Task<List<PasswordEntry>> GetAllPasswordEntries(int userId);
    Task<PasswordEntry> UpdatePasswordEntry(PasswordEntry entry);
    Task DeletePasswordEntry(int id);
}