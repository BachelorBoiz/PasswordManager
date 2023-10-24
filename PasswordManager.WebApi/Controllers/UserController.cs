using System.Security.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Core.Abstractions;
using PasswordManager.Core.IServices;
using PasswordManager.Core.Models;
using PasswordManager.WebApi.Dtos;
using PasswordManager.WebApi.Services;

namespace PasswordManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtService _jwtService;
        
        public UserController(IUserService userService, IPasswordHasher passwordHasher, IJwtService jwtService)
        {
            _passwordHasher = passwordHasher;
            _userService = userService;
            _jwtService = jwtService;
        }

        //[HttpGet]
        //public async Task<ActionResult<User>> GetUser(string email)
        //{
        //    var user = await _userService.GetUser(email);
        //    if (user is null)
        //    {
        //        return BadRequest("User not found");
        //    }

        //    return Ok(user);
        //}

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="createUserDto"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("create/user")]
        public async Task<ActionResult<TokenDto>> AddUser(CreateUserDto createUserDto)
        {
            var user = await _userService.GetUser(createUserDto.Email);

            if (user is not null) return BadRequest("User with given email already exists");

            var newUser = new User
            {
                Email = createUserDto.Email,
                HashedPassword = _passwordHasher.Hash(createUserDto.Password)
            };

            await _userService.AddUser(newUser);

            var token = await _jwtService.GenerateJwt(createUserDto.Email, createUserDto.Password);
            var newToken = new TokenDto
            {
                Message = token.Message,
                Jwt = token.Jwt
            };

            return Ok(newToken);
        }

        /// <summary>
        /// If successful, return a jwt 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost(nameof(Login))]
        public async Task<ActionResult<TokenDto>> Login(LoginDto dto)
        {
            try
            {
                var token = await _jwtService.GenerateJwt(dto.Email, dto.Password);
                return new TokenDto
                {
                    Jwt = token.Jwt,
                    Message = token.Message
                };
            }
            catch (AuthenticationException ae)
            {
                return Unauthorized(ae.Message);
            }
        }
    }
}
