using PasswordManager.Core.Models;

namespace PasswordManager.Core.IServices;

public interface IUserService
{
    Task<User> AddUser(User user);
    Task<User?> GetUser(string email);
}