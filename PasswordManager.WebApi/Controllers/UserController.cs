using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Core.Abstractions;
using PasswordManager.Core.IServices;
using PasswordManager.Core.Models;
using PasswordManager.WebApi.Dtos;

namespace PasswordManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPasswordHasher _passwordHasher;
        
        public UserController(IUserService userService, IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetUser(string email)
        {
            var user = await _userService.GetUser(email);
            if (user is null)
            {
                return BadRequest("User not found");
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(CreateUserDto createUserDto)
        {
            var newUser = new User
            {
                Email = createUserDto.Email,
                HashedPassword = _passwordHasher.Hash(createUserDto.Password)
            };

            await _userService.AddUser(newUser);
            return Ok();
        }
    }
}
