using MarketPlace.Core.Models;

namespace MarketPlace.Core.Interfaces.Repositories
{
    public interface ISellerRepository
    {
        Task<Guid> AddSellerAsync(SellerModel seller);
        Task<SellerModel?> GetSellerByIdAsync(Guid id);
        Task<Guid> RemoveSellerAsync(Guid sellerId);
    }
}