using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("ReviewList")]
        public async Task<IActionResult> ReviewList()
        {
            return Ok();
        }

        [HttpPut("AddReview")]
        public async Task<IActionResult> AddReview()
        {
            return Ok();
        }

        [HttpPut("UpdateReview")]
        public async Task<IActionResult> UpdateReview()
        {
            return Ok();
        }

        [HttpDelete("DeleteReview")]
        public async Task<IActionResult> DeleteReview()
        {
            return Ok();
        }
    }
}
