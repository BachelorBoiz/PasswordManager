using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.Core.IServices;
using PasswordManager.Core.Models;
using PasswordManager.Domain.IRepositories;

namespace PasswordManager.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<User> AddUser(User user)
        {
            return await _repository.AddUser(user);
        }

        public async Task<User?> GetUser(string email)
        {
            return await _repository.GetUser(email);
        }
    }
}
