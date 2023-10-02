using PasswordManager.Core.Models;
using PasswordManager.Domain.IRepositories;

namespace PasswordManager.Infrastructure.Repositories;

public class PasswordEntryRepository : IPasswordEntryRepository
{
    public PasswordEntry GetPasswordEntry(string website)
    {
        throw new NotImplementedException();
    }

    public List<PasswordEntry> GetAllPasswordEntries()
    {
        throw new NotImplementedException();
    }

    public PasswordEntry SavePasswordEntry(PasswordEntry entry)
    {
        throw new NotImplementedException();
    }

    public PasswordEntry UpdatePasswordEntry(PasswordEntry entry)
    {
        throw new NotImplementedException();
    }

    public PasswordEntry DeletePasswordEntry(string website)
    {
        throw new NotImplementedException();
    }
}