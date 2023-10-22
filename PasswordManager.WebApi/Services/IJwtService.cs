using Microsoft.IdentityModel.JsonWebTokens;
using PasswordManager.WebApi.Models;

namespace PasswordManager.WebApi.Services
{
    public interface IJwtService
    {
        /// <summary>
        /// Generate Jwt
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<JwtToken> GenerateJwt(string email, string password);
    }
}
