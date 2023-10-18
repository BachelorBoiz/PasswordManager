using PasswordManager.Core.Models;

namespace PasswordManager.Domain.IRepositories;

public interface IUserRepository
{
    Task<User> AddUser(User user);
    Task<User?> GetUser(string email);
}