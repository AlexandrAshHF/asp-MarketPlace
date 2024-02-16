using MarketPlace.API.Contracts.CategoryDTO;
using MarketPlace.Application.Services;
using MarketPlace.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace MarketPlace.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private CategoriesService _categoryService;
        public CategoryController(CategoriesService categoryService)
        {
            _categoryService = categoryService;
        }

        [AllowAnonymous]
        [HttpGet("CategoryList")]
        public async Task<IActionResult> CategoryList(Guid? parrentId)
        {
            List<CategoryModel> models = new List<CategoryModel>();

            if (parrentId == null)
                models = _categoryService.GetParrentUpCategories();

            else
                models = await _categoryService.GetChildrenByIdAsync(parrentId);

            return Ok(models);
        }

        [HttpPut("AddCategory")]
        public async Task<IActionResult> AddCategory(CategoryRequestDTO requestDTO)
        {
            var response = await _categoryService.AddCategoryAsync(requestDTO.Id, requestDTO.Title,
                requestDTO.Characteristics, requestDTO.ParrentId);

            if (!response.Item2.IsNullOrEmpty())
                return BadRequest(response.Item2);

            return Ok(response.Item1);
        }

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(CategoryRequestDTO requestDTO)
        {
            var response = await _categoryService.AddCategoryAsync(requestDTO.Id, requestDTO.Title,
                requestDTO.Characteristics, requestDTO.ParrentId);

            if (!response.Item2.IsNullOrEmpty())
                return BadRequest(response.Item2);

            return Ok(response.Item1);
        }

        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var response = await _categoryService.DeleteCategoryAsync(id);

            return Ok(response);
        }
    }
}
