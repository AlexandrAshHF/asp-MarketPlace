using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder()
        {
            return Ok();
        }

        [HttpGet("OrderList")]
        public async Task<IActionResult> OrderList()
        {
            return Ok();
        }

        [HttpGet("SelectedOrder")]
        public async Task<IActionResult> SelectedOrder()
        {
            return Ok();
        }
    }
}
