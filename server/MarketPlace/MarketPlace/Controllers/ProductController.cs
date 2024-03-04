using MarketPlace.API.Contracts.ProductDTO.Requests;
using MarketPlace.API.Contracts.ProductDTO.Responses;
using MarketPlace.Core.Interfaces.DataIntefaces;
using MarketPlace.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace MarketPlace.API.Controllers
{
    [Authorize(Roles = "Seller")]
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductsService _productsService;
        private ISellerRepository _sellerRepository;
        public ProductController(IProductsService productsService, ISellerRepository sellerRepository)
        {
            _productsService = productsService;
            _sellerRepository = sellerRepository;
        }

        [AllowAnonymous]
        [HttpGet("ProductsList")]
        public IActionResult ProductsList()
        {
            List<ProductResponseDTO> products = new List<ProductResponseDTO>();

            products = _productsService.GetAllProducts()
            .Select(item => new ProductResponseDTO
            {
                Id = item.Id,
                Title = item.Title,
                TypeName = item.TypeName ?? string.Empty,
                ImageLink = item.ImageLinks.FirstOrDefault() ?? string.Empty,
                Price = item.Price,
            }).ToList();

            return Ok(products);
        }

        [AllowAnonymous]
        [HttpPost("ProductsRangeById")]
        public IActionResult ProductsRangeById(List<Guid> requestProductsId)
        {
            List<ProductResponseDTO> products = new List<ProductResponseDTO>();

            products = _productsService.GetRangeProductsById(requestProductsId)
              .Select(item => new ProductResponseDTO
              {
                  Id = item.Id,
                  Title = item.Title,
                  TypeName = item.TypeName ?? string.Empty,
                  ImageLink = item.ImageLinks.FirstOrDefault() ?? string.Empty,
                  Price = item.Price,
              }).ToList();

            return Ok(products);
        }

        [AllowAnonymous]
        [HttpGet("SelectedProduct")]
        public async Task<IActionResult> SelectedProduct(Guid id)
        {
            var product = await _productsService.FindProductByIdAsync(id);

            if (product == null)
                return BadRequest(id);

            var seller = await _sellerRepository.GetSellerByProductId(id);

            var response = new SelectedProductResponseDTO
            {
                Id = product.Id,
                SellerId = seller.Id,
                Title = product.Title,
                Description = product.Description,
                TypeName = product.TypeName ?? string.Empty,
                ImageLinks = product.ImageLinks ?? new List<string>(),
                Price = product.Price,
                SellerName = seller.User.Username,
            };

            return Ok(response);
        }

        [HttpPut("AddProduct")]
        public async Task<IActionResult> AddProduct(ProductRequestDTO requestDTO)
        {
            var userClaims = User.Identity as ClaimsIdentity;
            var sellerId = userClaims.FindFirst("sellerId").Value ?? throw new ArgumentNullException("userClaims.FindFirst(\"sellerId\")", "Missing sellerId in Claims");

            var response = await _productsService.AddProductAsync(Guid.NewGuid(), requestDTO.Title, requestDTO.TypeName, requestDTO.Description,
                requestDTO.ImageLinks, requestDTO.Price, requestDTO.CategoryId, new Guid(sellerId));

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
            var userClaims = User.Identity as ClaimsIdentity;
            var sellerId = userClaims.FindFirst("sellerId").Value ?? throw new ArgumentNullException("userClaims.FindFirst(\"sellerId\")", "Missing sellerId in Claims");

            var response = await _productsService.UpdateProductAsync(requestDTO.Id, requestDTO.Title, requestDTO.TypeName, requestDTO.Description,
                        requestDTO.ImageLinks, requestDTO.Price, requestDTO.CategoryId, new Guid(sellerId));

            if (!response.Item2.IsNullOrEmpty())
                return BadRequest(response.Item2);

            return Ok(response);
        }

        [HttpGet("SellerProductsList")]
        public async Task<IActionResult> SellerProductsList()
        {
            return Ok();
        }
    }
}