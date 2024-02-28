using MarketPlace.API.Contracts.AuthDTO;
using MarketPlace.API.Contracts.UserDTO;
using MarketPlace.Core.Interfaces.Auth;
using MarketPlace.Core.Interfaces.DataIntefaces;
using MarketPlace.Core.Interfaces.Repositories;
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
        private IOrdersService _ordersService;
        public AccountController(IUsersService userService, IOrdersService ordersService, ISellerRepository sellerRepository)
        {
            _userService = userService;
            _ordersService = ordersService;
        }

        [Authorize]
        [HttpGet("Profile")]
        public async Task<IActionResult> Profile()
        {
            var userClaims = User.Identity as ClaimsIdentity;
            var userId = userClaims.FindFirst("userId").Value;

            if (userId.IsNullOrEmpty())
                return BadRequest();

            var model = await _userService.GetUserById(new Guid(userId));
            var orders = await _ordersService.GetOrdersByUserIdAsync(model.Id);

            var response = new ProfileResponseDTO
            {
                Id = model.Id,
                Email = model.Email,
                Username = model.Username,
                SellerId = model.SellerId.IsNullOrEmpty() ? null : new Guid(model.SellerId),
                Orders = orders.Select(x => new OrderModule(x.Id, string.Empty,
                x.Products.Aggregate(0M, (total, second) => total + second.Price))).ToList(),
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
        [HttpPost("RegistrationSeller")]
        public async Task<IActionResult> RegistrationSeller(string phoneNumber)
        {
            
            return Ok();
        }
    }
}