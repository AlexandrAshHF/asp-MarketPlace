using MarketPlace.Core.Models;

namespace MarketPlace.Core.Interfaces.Repositories
{
    public interface ISellerRepository
    {
        Task<Guid> AddSellerAsync(SellerModel seller);
        Task<SellerModel?> GetSellerByIdAsync(Guid id);
        Task<SellerModel> GetSellerByProductId(Guid productId);
        Task<Guid> RemoveSellerAsync(Guid sellerId);
    }
}