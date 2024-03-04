using MarketPlace.Core.Models;

namespace MarketPlace.Core.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<Guid> AddProductAsync(ProductModel product, Guid CategoryId, Guid SellerId);
        Task<Guid> DeleteProductAsync(Guid id);
        Task<ProductModel?> FindProductByIdAsync(Guid id);
        Task<List<ProductModel>?> GetProductsByCategoryIdAsync(Guid id);
        List<ProductModel>? GetAllProducts();
        Task<Guid> UpdateProductAsync(ProductModel product, Guid CategoryId, Guid SellerId);
        Task<List<ProductModel>?> GetProductsBySellerIdAsync(Guid sellerId);
        List<ProductModel> GetRangeProductsById(List<Guid> productsId);
    }
}