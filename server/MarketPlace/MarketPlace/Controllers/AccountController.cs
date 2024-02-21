using MarketPlace.API.Contracts.AuthDTO;
using MarketPlace.API.Contracts.UserDTO;
using MarketPlace.Core.Interfaces.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace MarketPlace.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IUsersService _userService;
        public AccountController(IUsersService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet("Profile")]
        public async Task<IActionResult> Profile()
        {
            var userClaims = User.Identity as ClaimsIdentity;
            var userId = userClaims.FindFirst("userId").Value;

            if (userId == null)
                return BadRequest();

            var model = await _userService.GetUserById(new Guid(userId));
            var response = new ProfileResponseDTO
            {
                Id = model.Id,
                Email = model.Email,
                EmailConfirm = model.EmailConfirm,
                Username = model.Username,
                SellerId = model.SellerId,
            };

            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequestDTO request)
        {
            var response = await _userService.Login(request.Email, request.Password);

            if (!response.Item2.IsNullOrEmpty())
                return BadRequest(response.Item2);

            Response.Headers.Append("Authorization", $"Bearer {response.Item1}");

            return Ok(response.Item1);
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Registration(RegistrationRequestDTO request)
        {
            var response = await _userService.Registration(request.Email, request.Username, request.Password);

            if (!response.Item2.IsNullOrEmpty())
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

        [Authorize]
        [HttpPost("RegistrationSeller")]
        public async Task<IActionResult> RegistrationSeller()
        {
            return Ok();
        }
    }
}