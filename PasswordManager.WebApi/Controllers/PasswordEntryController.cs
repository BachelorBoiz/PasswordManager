using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Core.IServices;
using PasswordManager.Core.Models;

namespace PasswordManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordEntryController : ControllerBase
    {
        private readonly IPasswordEntryService _passwordEntryService;

        public PasswordEntryController(IPasswordEntryService passwordEntryService)
        {
            _passwordEntryService = passwordEntryService;
        }

        [HttpPost]
        public async Task<ActionResult<PasswordEntry>> AddPassword(PasswordEntry newPassword)
        {
            await _passwordEntryService.AddPasswordEntry(newPassword);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PasswordEntry>>> GetAllPasswordEntries()
        {
            var passwords = await _passwordEntryService.GetAllPasswordEntries();
            return Ok(passwords);
        }

        [HttpDelete("{id})")]
        public async Task<ActionResult> DeletePassword(int id)
        {
            await _passwordEntryService.DeletePasswordEntry(id);

            return Ok();
        }
    }
}
