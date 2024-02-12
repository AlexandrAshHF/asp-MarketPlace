using MarketPlace.API.Contracts.ProductDTO.Requests;
using MarketPlace.API.Contracts.ProductDTO.Responses;
using MarketPlace.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace MarketPlace.API.Controllers
{
    [Authorize(Roles = "Seller")]
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductsService _productsService;
        public ProductController(ProductsService productsService)
        {
            _productsService = productsService;
        }

        [AllowAnonymous]
        [HttpGet("ProductList")]
        public IActionResult ProductList()
        {
            var products = _productsService.GetAllProducts()
                .Select(x => new ProductResponseDTO
                {
                    Id = x.Id,
                    Title = x.Title,
                    TypeName = x.TypeName,
                    ImageLink = x.ImageLinks[0] ?? string.Empty,
                    Price = x.Price,
                });

            return Ok(products);
        }

        [AllowAnonymous]
        [HttpGet("SelectedProduct")]
        public async Task<IActionResult> SelectedProduct(Guid id)
        {
            var product = await _productsService.FindProductByIdAsync(id);

            if (product == null)
                return BadRequest(id);

            var response = new SelectedProductResponseDTO
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                TypeName = product.TypeName ?? string.Empty,
                ImageLinks = product.ImageLinks ?? new List<string>(),
                Price = product.Price,
            };

            return Ok(response);
        }

        [HttpPut("AddProduct")]
        public async Task<IActionResult> AddProduct(ProductRequestDTO requestDTO)
        {
            var response = await _productsService.AddProductAsync(Guid.NewGuid(), requestDTO.Title, requestDTO.TypeName, requestDTO.Description,
                requestDTO.ImageLinks, requestDTO.Price, requestDTO.CategoryId, Guid.NewGuid()); // вместо newGuid для seller-а извлечь id из jwt токена

            if (!response.Item2.IsNullOrEmpty())
                return BadRequest(response.Item2);

            return Ok(response.Item1);
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var response = await _productsService.DeleteProductAsync(id);

            return Ok(id);
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(ProductRequestDTO requestDTO)
        {
            var response = await _productsService.UpdateProductAsync(requestDTO.Id, requestDTO.Title, requestDTO.TypeName, requestDTO.Description,
                        requestDTO.ImageLinks, requestDTO.Price, requestDTO.CategoryId, Guid.NewGuid()); // вместо newGuid для seller-а извлечь id из jwt токена

            if (!response.Item2.IsNullOrEmpty())
                return BadRequest(response.Item2);

            return Ok(response);
        }
    }
}