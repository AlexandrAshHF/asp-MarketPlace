using MarketPlace.Core.Interfaces.DataIntefaces;
using MarketPlace.Core.Interfaces.Repositories;
using MarketPlace.Core.Models;
using Microsoft.IdentityModel.Tokens;

namespace MarketPlace.Application.Services
{
    public class ProductsService : IProductsService
    {
        private IProductRepository _productRepository;
        public ProductsService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<(Guid, string)> AddProductAsync(Guid id, string title, string? typeName,
            string desc, List<string> imgList, decimal price,
            Guid CategoryId, Guid SellerId)
        {
            var product = ProductModel.CreateProduct(id, title, typeName, desc, imgList, price);

            if (!product.Item2.IsNullOrEmpty())
                return (Guid.Empty, product.Item2);

            return (await _productRepository.AddProductAsync(product.Item1, CategoryId, SellerId), string.Empty);
        }
        public async Task<Guid> DeleteProductAsync(Guid id)
        {
            return await _productRepository.DeleteProductAsync(id);
        }
        public async Task<ProductModel?> FindProductByIdAsync(Guid id)
        {
            return await _productRepository.FindProductByIdAsync(id);
        }
        public async Task<List<ProductModel>?> GetProductsByCategoryIdAsync(Guid id)
        {
            return await _productRepository.GetProductsByCategoryIdAsync(id);
        }
        public List<ProductModel> GetAllProducts()
        {
            var products = _productRepository.GetAllProducts();

            if (products.IsNullOrEmpty())
                return new List<ProductModel>();

            return products;
        }
        public async Task<(Guid, string)> UpdateProductAsync(Guid id, string title, string? typeName,
            string desc, List<string> imgList, decimal price,
            Guid CategoryId, Guid SellerId)
        {
            var product = ProductModel.CreateProduct(id, title, typeName, desc, imgList, price);

            if (!product.Item2.IsNullOrEmpty())
                return (id, product.Item2);

            return (await _productRepository.UpdateProductAsync(product.Item1, CategoryId, SellerId), string.Empty);
        }
        public async Task<List<ProductModel>?> GetProductsBySellerIdAsync(Guid sellerId)
        {
            return await _productRepository.GetProductsBySellerIdAsync(sellerId);
        }
    }
}