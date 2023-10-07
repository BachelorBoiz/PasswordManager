using PasswordManager.Core.Models;

namespace PasswordManager.Core.IServices;

public interface IPasswordEntryService
{
    Task<PasswordEntry> AddPasswordEntry(PasswordEntry entry);
    Task<PasswordEntry?> GetPasswordEntry(string website);
    Task<List<PasswordEntry>> GetAllPasswordEntries();
    Task<PasswordEntry> UpdatePasswordEntry(PasswordEntry entry);
    Task DeletePasswordEntry(string website);
}