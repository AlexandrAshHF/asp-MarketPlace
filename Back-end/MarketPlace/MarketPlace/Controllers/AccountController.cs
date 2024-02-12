using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [Authorize]
        [HttpGet("Profile")]
        public async Task<IActionResult> Profile()
        {
            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login()
        {
            return Ok();
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Registration()
        {
            return Ok();
        }

        [Authorize]
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            return Ok();
        }
    }
}