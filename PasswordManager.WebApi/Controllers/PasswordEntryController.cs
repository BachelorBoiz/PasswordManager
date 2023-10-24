using System.Collections;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Core.Abstractions;
using PasswordManager.Core.IServices;
using PasswordManager.Core.Models;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using PasswordManager.WebApi.Dtos;

namespace PasswordManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordEntryController : ControllerBase
    {
        private readonly IPasswordEntryService _passwordEntryService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserService _userService;

        public PasswordEntryController(IPasswordEntryService passwordEntryService, IPasswordHasher passwordHasher, IUserService userService)
        {
            _passwordEntryService = passwordEntryService;
            _passwordHasher = passwordHasher;
            _userService = userService;
        }

        /// <summary>
        /// Add new password
        /// </summary>
        /// <param name="newPasswordEntry"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<PasswordEntryDto>> AddPassword(PasswordEntryDto newPasswordEntry)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);

            var user = await _userService.GetUser(userEmail);

            if (user is null)
            {
                return BadRequest("Wrong user");
            }

            var password = await _passwordEntryService.AddPasswordEntry(new PasswordEntry
            {
                Password = newPasswordEntry.Password,
                Username = newPasswordEntry.Username,
                Website = newPasswordEntry.Website,
                User = new User
                {
                    Email = user.Email,
                    Id = user.Id
                }
            });

            return Ok(password);
        }

        /// <summary>
        /// Returns all password entries.
        /// The frontend will decrypt the passwords.
        /// </summary>
        /// <param name="masterPassword"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PasswordEntryDto>>> GetAllPasswordEntries()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);

            var user = await _userService.GetUser(userEmail);

            if (user is null)
            {
                return BadRequest("Wrong user");
            }

            var passwords = await _passwordEntryService.GetAllPasswordEntries(user.Id);

            var passwordDtos = passwords.Select(password => 
                new PasswordEntryDto { Password = password.Password, Username = password.Username, Website = password.Website, Id = password.Id})
                .AsEnumerable();

            return Ok(passwordDtos);
        }

        /// <summary>
        /// Delete password
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePassword(int id)
        {
            await _passwordEntryService.DeletePasswordEntry(id);

            return Ok();
        }
    }
}
