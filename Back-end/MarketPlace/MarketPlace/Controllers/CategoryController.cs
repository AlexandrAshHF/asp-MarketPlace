using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet("CategoryList")]
        public async Task<IActionResult> CategoryList()
        {
            return Ok();
        }

        [HttpPut("AddCategory")]
        public async Task<IActionResult> AddCategory()
        {
            return Ok();
        }

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory()
        {
            return Ok();
        }

        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory()
        {
            return Ok();
        }
    }
}
