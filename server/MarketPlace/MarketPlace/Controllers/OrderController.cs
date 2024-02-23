using MarketPlace.API.Contracts.OrderDTO;
using MarketPlace.Core.Interfaces.DataIntefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace MarketPlace.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrdersService _ordersService;
        public OrderController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder(OrderRequestDTO requestDTO)
        {
            var userClaims = User.Identity as ClaimsIdentity;
            var userId = userClaims.FindFirst("userId").Value;

            if (userId.IsNullOrEmpty())
                return BadRequest("UserId is null");

            var response = await _ordersService.AddOrder(Guid.NewGuid(), new Guid(userId), requestDTO.placeId, requestDTO.productsId);

            return Ok(response);
        }

        [HttpGet("OrderList")]
        public async Task<IActionResult> OrderList()
        {
            var userClaims = User.Identity as ClaimsIdentity;
            var userId = userClaims.FindFirst("userId").Value;

            if (userId.IsNullOrEmpty())
                return BadRequest("UserId is null");

            var response = await _ordersService.GetOrdersByUserIdAsync(new Guid(userId));

            return Ok(response);
        }

        [HttpGet("SelectedOrder")]
        public async Task<IActionResult> SelectedOrder(Guid id)
        {
            var response = await _ordersService.GetOrderById(id);
            return Ok(response);
        }
    }
}
