using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.Core.Models;

namespace PasswordManager.Infrastructure.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public ICollection<PasswordEntryEntity>? Passwords { get;}
    }
}
