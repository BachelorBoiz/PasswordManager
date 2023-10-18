using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PasswordManager.Core.Models;
using PasswordManager.Domain.IRepositories;
using PasswordManager.Infrastructure.Entities;

namespace PasswordManager.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PasswordManagerDbContext _ctx;

        public UserRepository(PasswordManagerDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<User> AddUser(User user)
        {
            var entity = new UserEntity
            {
                Email = user.Email,
                HashedPassword = user.HashedPassword
            };

             await _ctx.Users.AddAsync(entity);
             await _ctx.SaveChangesAsync();

             user.Id = entity.Id;
             
             return user;
        }

        public async Task<User?> GetUser(string email)
        {
            return await _ctx.Users
                .Where(entity => entity.Email == email)
                .Select(entity => new User
                {
                    Id = entity.Id,
                    Email = entity.Email,
                    HashedPassword = entity.HashedPassword
                }).FirstOrDefaultAsync();
        }
    }
}
