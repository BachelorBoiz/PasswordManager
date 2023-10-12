using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Core.Abstractions
{
    public interface IPasswordHasher
    {
        string Hash(string password, byte[] salt);
        bool Verify(string password, string InputPassword);

    }
}
