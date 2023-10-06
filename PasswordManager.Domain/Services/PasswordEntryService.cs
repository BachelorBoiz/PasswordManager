using PasswordManager.Core.IServices;
using PasswordManager.Core.Models;
using PasswordManager.Domain.IRepositories;

namespace PasswordManager.Domain.Services;

public class PasswordEntryService : IPasswordEntryService
{
    private readonly IPasswordEntryRepository _passwordEntryRepository;
    
    public PasswordEntryService(IPasswordEntryRepository passwordEntryRepository)
    {
        _passwordEntryRepository = passwordEntryRepository;
    }
    public PasswordEntry AddPasswordEntry(PasswordEntry entry)
    {
        _passwordEntryRepository.SavePasswordEntry(entry);
        return entry;
    }

    public PasswordEntry? GetPasswordEntry(string website)
    {
        return _passwordEntryRepository.GetPasswordEntry(website);
    }

    public List<PasswordEntry> GetAllPasswordEntries()
    {
        var passwordEntries = _passwordEntryRepository.GetAllPasswordEntries();
        return passwordEntries;
    }

    public PasswordEntry UpdatePasswordEntry(PasswordEntry entry)
    {
        _passwordEntryRepository.UpdatePasswordEntry(entry);
        return entry;
    }

    public PasswordEntry DeletePasswordEntry(string website)
    {
        var deletedEntry = _passwordEntryRepository.DeletePasswordEntry(website);
        return deletedEntry;
    }
}