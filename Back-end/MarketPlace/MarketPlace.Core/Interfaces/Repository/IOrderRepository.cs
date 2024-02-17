using MarketPlace.Core.Models;

namespace MarketPlace.Core.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<Guid> AddOrder(OrderModel model);
        Task<OrderModel> GetOrderById(Guid id);
        Task<List<OrderModel>> GetOrdersByUserIdAsync(Guid id);
    }
}