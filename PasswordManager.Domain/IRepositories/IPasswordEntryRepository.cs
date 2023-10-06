using PasswordManager.Core.Models;

namespace PasswordManager.Domain.IRepositories;

public interface IPasswordEntryRepository
{
    PasswordEntry? GetPasswordEntry(string website);
    List<PasswordEntry> GetAllPasswordEntries();
    PasswordEntry SavePasswordEntry(PasswordEntry entry);
    PasswordEntry UpdatePasswordEntry(PasswordEntry entry);
    PasswordEntry DeletePasswordEntry(string website);
}