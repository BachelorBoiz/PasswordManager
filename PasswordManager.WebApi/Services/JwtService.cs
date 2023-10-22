using Microsoft.IdentityModel.Tokens;
using PasswordManager.Core.Abstractions;
using PasswordManager.Core.IServices;
using PasswordManager.WebApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PasswordManager.WebApi.Services
{
    public class JwtService : IJwtService
    {
        private readonly IUserService _userService;
        private readonly IPasswordHasher _passwordHasher;
        public IConfiguration Configuration { get; }

        public JwtService(IConfiguration configuration, IUserService userService, IPasswordHasher passwordHasher)
        {
            Configuration = configuration;
            _userService = userService;
            _passwordHasher = passwordHasher;
        }

        /// <summary>
        /// Generate Jwt
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<JwtToken> GenerateJwt(string email, string password)
        {
            var user = await _userService.GetUser(email);

            if (_passwordHasher.Verify(user.HashedPassword, password))
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Secret"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(Configuration["Jwt:Issuer"],
                    Configuration["Jwt:Audience"],
                    new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Email, user.Email)
                    },
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: credentials);
                return new JwtToken
                {
                    Jwt = new JwtSecurityTokenHandler().WriteToken(token),
                    Message = "Ok"
                };
            }
            return new JwtToken
            {
                Message = "User or Password not correct"
            };
        }
        
    }
}
