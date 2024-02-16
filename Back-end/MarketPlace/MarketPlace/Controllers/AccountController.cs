using MarketPlace.API.Contracts.AuthDTO;
using MarketPlace.Core.Interfaces.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace MarketPlace.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IUsersService _authService;
        public AccountController(IUsersService authService)
        {
            _authService = authService;
        }

        [Authorize]
        [HttpGet("Profile")]
        public async Task<IActionResult> Profile()
        {
            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequestDTO request)
        {
            var response = await _authService.Login(request.Email, request.Password);

            if(!response.Item2.IsNullOrEmpty())
                return BadRequest(response.Item2);

            Response.Headers.Append("Authorization", $"Bearer {response.Item1}");

            return Ok(response.Item1);
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Registration(RegistrationRequestDTO request)
        {
            var response = await _authService.Registration(request.Email, request.Username, request.Password);

            if(!response.Item2.IsNullOrEmpty())
                return BadRequest(response.Item2);

            return Ok(response.Item1);
        }

        [Authorize]
        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            var result = Response.Headers.Remove("Authorization");
            return result ? Ok() : BadRequest();
        }
    }
}