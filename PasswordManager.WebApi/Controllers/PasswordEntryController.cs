using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Core.Abstractions;
using PasswordManager.Core.IServices;
using PasswordManager.Core.Models;
using System.Security.Cryptography;
using PasswordManager.WebApi.Dtos;

namespace PasswordManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordEntryController : ControllerBase
    {
        private readonly IPasswordEntryService _passwordEntryService;
        private readonly IPasswordHasher _passwordHasher;

        public PasswordEntryController(IPasswordEntryService passwordEntryService, IPasswordHasher passwordHasher)
        {
            _passwordEntryService = passwordEntryService;
            _passwordHasher = passwordHasher;
        }

        [HttpPost]
        public async Task<ActionResult<PasswordEntry>> AddPassword(PasswordEntry newPassword)
        {
            await _passwordEntryService.AddPasswordEntry(newPassword);

            return Ok();
        }

        /// <summary>
        /// Calling this endpoint with masterPassword as "123456" will return all saved passwords as encrypted.
        /// The frontend will decrypt the passwords.
        /// </summary>
        /// <param name="masterPassword"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost("passwords")]
        public async Task<ActionResult<IEnumerable<PasswordEntry>>> GetAllPasswordEntries([FromBody] GetPassword masterPassword)
        {
            // Plaintext password, this is only done for demonstration purposes, and would be saved as a hashed password in a database in a real scenario
            var password = "123456";

            var salt = RandomNumberGenerator.GetBytes(128 / 8);
            password = _passwordHasher.Hash(password, salt);

            if (!_passwordHasher.Verify(password, masterPassword.MasterPassword))
                throw new Exception("Wrong master password");

            var passwords = await _passwordEntryService.GetAllPasswordEntries();
            return Ok(passwords);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePassword(int id)
        {
            await _passwordEntryService.DeletePasswordEntry(id);

            return Ok();
        }
    }
}
