using MarketPlace.Core.Models;

namespace MarketPlace.Core.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<Guid> AddOrder(OrderModel model);
        Task<Guid> DeleteOrder(Guid id);
        Task<OrderModel> GetOrderById(Guid id);
        Task<List<OrderModel>> GetOrdersBySellerIdAsync(Guid sellerId);
        Task<List<OrderModel>> GetOrdersByUserIdAsync(Guid id);
    }
}