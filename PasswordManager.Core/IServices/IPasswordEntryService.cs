using PasswordManager.Core.Models;

namespace PasswordManager.Core.IServices;

public interface IPasswordEntryService
{
    PasswordEntry AddPasswordEntry(PasswordEntry entry);
    PasswordEntry? GetPasswordEntry(string website);
    List<PasswordEntry> GetAllPasswordEntries();
    PasswordEntry UpdatePasswordEntry(PasswordEntry entry);
    PasswordEntry DeletePasswordEntry(string website);
}