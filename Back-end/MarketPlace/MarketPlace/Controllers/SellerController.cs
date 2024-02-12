using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.API.Controllers
{
    [Authorize(Roles = "Seller")]
    [Route("[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        [HttpGet("SellerProducts")]
        public async Task<IActionResult> SellerProducts()
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("RegistrationSeller")]
        public async Task<IActionResult> RegistrationSeller()
        {
            return Ok();
        }
    }
}
