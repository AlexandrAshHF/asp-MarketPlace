using MarketPlace.Core.Models;

namespace MarketPlace.Core.Interfaces.DataIntefaces
{
    public interface IProductsService
    {
        Task<(Guid, string)> AddProductAsync(Guid id, string title, string? typeName, string desc, List<string> imgList, decimal price, Guid CategoryId, Guid SellerId);
        Task<Guid> DeleteProductAsync(Guid id);
        Task<ProductModel?> FindProductByIdAsync(Guid id);
        List<ProductModel> GetAllProducts();
        Task<List<ProductModel>?> GetProductsByCategoryIdAsync(Guid id);
        Task<List<ProductModel>?> GetProductsBySellerIdAsync(Guid sellerId);
        List<ProductModel> GetRangeProductsById(List<Guid> productsId);
        Task<(Guid, string)> UpdateProductAsync(Guid id, string title, string? typeName, string desc, List<string> imgList, decimal price, Guid CategoryId, Guid SellerId);
    }
}