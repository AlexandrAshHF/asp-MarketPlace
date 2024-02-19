using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("PlacesList")]
        public async Task<IActionResult> PlacesList()
        {
            return Ok();
        }

        [HttpPut("AddPlace")]
        public async Task<IActionResult> AddPlace()
        {
            return Ok();
        }

        [HttpPut("UpdatePlace")]
        public async Task<IActionResult> UpdatePlace()
        {
            return Ok();
        }

        [HttpDelete("DeletePlace")]
        public async Task<IActionResult> DeletePlace()
        {
            return Ok();
        }
    }
}