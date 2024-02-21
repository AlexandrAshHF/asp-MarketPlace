using MarketPlace.Application.Services;
using MarketPlace.Core.Interfaces.DataIntefaces;
using MarketPlace.Core.Interfaces.Repositories;
using MarketPlace.DAL.Repositories;
using MarketPlace.UnitTests.Common;
using Xunit;
using Xunit.Sdk;

namespace MarketPlace.UnitTests.ServicesTest
{
    public class ProductsServiceTests : TestServiceBase
    {
        private readonly IProductsService _productsService;

        public ProductsServiceTests() : base()
        {
            IProductRepository productRepository = new ProductRepository(_context);
            _productsService = new ProductsService(productRepository);
        }

        [Theory]
        [MemberData(nameof(DataToAddProductTest))]
        public async Task AddProductTest_Success(Guid id, string title, string? typeName,
            string desc, List<string> imgList, decimal price,
            Guid CategoryId, Guid SellerId, Guid expectedGuid)
        {
            var result = await _productsService.AddProductAsync(id, title, typeName, desc, imgList, price, CategoryId, SellerId);

            Assert.Equal(expectedGuid, result.Item1);
        }
        public static IEnumerable<object[]> DataToAddProductTest()
        {
            Guid id = Guid.NewGuid();
            yield return new object[] { id, "testTitle", "TestTypeName", "TestDescription",
                new List<string>(), 102.3M, ContextFactory.CategoryAId, ContextFactory.SellerAId,
                id};
            id = Guid.NewGuid();
            yield return new object[] { id, string.Empty, "TestTypeName", "TestDescription",
                new List<string>(), 102.3M, ContextFactory.CategoryAId, ContextFactory.SellerAId,
                Guid.Empty};
        }

    }
}
