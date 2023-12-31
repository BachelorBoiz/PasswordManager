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
    public async Task<PasswordEntry> AddPasswordEntry(PasswordEntry entry)
    {
        await _passwordEntryRepository.SavePasswordEntry(entry);
        return entry;
    }

    public async Task<PasswordEntry?> GetPasswordEntry(string website)
    {
        return await _passwordEntryRepository.GetPasswordEntry(website);
    }

    public async Task<List<PasswordEntry>> GetAllPasswordEntries(int userId)
    {
        var passwordEntries = await _passwordEntryRepository.GetAllPasswordEntries(userId);
        return passwordEntries;
    }

    public async Task<PasswordEntry> UpdatePasswordEntry(PasswordEntry entry)
    {
        await _passwordEntryRepository.UpdatePasswordEntry(entry);
        return entry;
    }

    public async Task DeletePasswordEntry(int id)
    {
        await _passwordEntryRepository.DeletePasswordEntry(id);
    }
}