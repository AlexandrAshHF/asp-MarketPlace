using MarketPlace.Core.Interfaces.Repositories;
using MarketPlace.Core.Models;

namespace MarketPlace.Application.Services
{
    public class ProductsService
    {
        private IProductRepository _productRepository;
        public ProductsService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Guid> AddProductAsync(ProductModel product, Guid CategoryId, Guid SellerId)
        {
            return await _productRepository.AddProductAsync(product, CategoryId, SellerId);
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
        public List<ProductModel>? GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }
        public async Task<Guid> UpdateProductAsync(ProductModel product, Guid CategoryId, Guid SellerId)
        {
            return await _productRepository.UpdateProductAsync(product, CategoryId, SellerId);
        }
        public async Task<List<ProductModel>?> GetProductsBySellerIdAsync(Guid sellerId)
        {
            return await _productRepository.GetProductsBySellerIdAsync(sellerId);
        }
    }
}