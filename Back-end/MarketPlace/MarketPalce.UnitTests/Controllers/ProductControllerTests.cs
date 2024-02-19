using MarketPalce.UnitTests.Common;
using MarketPlace.API.Contracts.ProductDTO.Requests;
using MarketPlace.API.Controllers;
using MarketPlace.Application.Services;
using MarketPlace.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MarketPalce.UnitTests.Services
{
    public class ProductControllerTests : TestSeviceBase
    {
        public ProductControllerTests():base() { }
        [Theory]
        [MemberData(nameof(ProductTestData))]
        public async Task TestAddProduct_Success(ProductRequestDTO requestDTO, IActionResult expected)
        {
            var productRepostiry = new ProductRepository(_context);
            var productService = new ProductsService(productRepostiry);
            var controller = new ProductController(productService);

            var result = await controller.AddProduct(requestDTO);

            Assert.Equal(expected, result);
        }
        public static IEnumerable<object[]> ProductTestData()
        {
            Guid id = Guid.NewGuid();
            yield return new object[] { new ProductRequestDTO 
            {
                Id = id,
                Title = "Title",
                Description = "Description",
                ImageLinks = new List<string>(),
                Price = 1.5M,
                TypeName = "Type",
            }, new OkObjectResult(id)};
            id = Guid.NewGuid();
            yield return new object[] { new ProductRequestDTO
            {
                Id = id,
                Title = string.Empty,
                Description = "Description",
                ImageLinks = new List<string>(),
                Price = 1.5M,
                TypeName = "Type",
            }, new BadRequestObjectResult("Description cannot be longer 75 characters and cannot be empty")};
            id = Guid.NewGuid();
            yield return new object[] { new ProductRequestDTO
            {
                Id = id,
                Title = "123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890",
                Description = "Description",
                ImageLinks = new List<string>(),
                Price = 1.5M,
                TypeName = "Type",
            }, new BadRequestObjectResult("Description cannot be longer 75 characters and cannot be empty")};
        }
    }
}
