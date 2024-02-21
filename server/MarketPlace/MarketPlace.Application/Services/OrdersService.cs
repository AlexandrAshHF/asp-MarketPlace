using MarketPlace.Core.Interfaces.DataIntefaces;
using MarketPlace.Core.Interfaces.Repositories;
using MarketPlace.Core.Models;
using Microsoft.IdentityModel.Tokens;

namespace MarketPlace.Application.Services
{
    public class OrdersService : IOrdersService
    {
        private IOrderRepository _orderRepository;
        private IProductRepository _productRepository;
        private IPlaceRepository _placeRepository;
        public OrdersService(IOrderRepository orderRepository,
            IProductRepository productRepository,
            IPlaceRepository placeRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _placeRepository = placeRepository;
        }

        public async Task<Guid> AddOrder(Guid id, Guid userId, Guid placeId, List<Guid> productsId)
        {
            var placeModel = await _placeRepository.GetPlaceById(placeId);

            List<ProductModel> productModels = new List<ProductModel>();
            foreach (var prodId in productsId)
            {
                var product = await _productRepository.FindProductByIdAsync(prodId);
                productModels.Add(product ?? throw new ArgumentNullException(nameof(product), "Product in AddOrder from OrdersService null"));
            }

            var model = OrderModel.CreateOrder(id, userId, placeModel, productModels);

            if (!model.Item2.IsNullOrEmpty())
                return Guid.Empty;

            return await _orderRepository.AddOrder(model.Item1);
        }
        public async Task<Guid> DeleteOrder(Guid id)
        {
            return await _orderRepository.DeleteOrder(id);
        }
        public async Task<OrderModel> GetOrderById(Guid id)
        {
            return await _orderRepository.GetOrderById(id);
        }
        public async Task<List<OrderModel>> GetOrdersBySellerIdAsync(Guid sellerId)
        {
            return await _orderRepository.GetOrdersBySellerIdAsync(sellerId);
        }
        public async Task<List<OrderModel>> GetOrdersByUserIdAsync(Guid id)
        {
            return await _orderRepository.GetOrdersByUserIdAsync(id);
        }
    }
}