using MarketPlace.Core.Models;

namespace MarketPlace.Core.Interfaces.DataIntefaces
{
    public interface IOrdersService
    {
        Task<Guid> AddOrder(Guid id, Guid userId, Guid placeId, List<Guid> productsId);
        Task<Guid> DeleteOrder(Guid id);
        Task<OrderModel> GetOrderById(Guid id);
        Task<List<OrderModel>> GetOrdersBySellerIdAsync(Guid sellerId);
        Task<List<OrderModel>> GetOrdersByUserIdAsync(Guid id);
    }
}