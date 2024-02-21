using MarketPlace.Core.Interfaces.Repositories;
using MarketPlace.Core.Models;
using MarketPlace.DAL.Enities;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private ApplicationContext _context;
        public OrderRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<List<OrderModel>> GetOrdersByUserIdAsync(Guid id)
        {
            var entities = await _context.Orders
                .Where(x => x.UserId == id)
                .Include(x => x.Products)
                .Include(x => x.Place)
                .ToListAsync();

            var products = new List<ProductModel>();
            foreach (var order in entities)
            {
                foreach (var product in order.Products)
                {
                    products.Add(ProductModel.CreateProduct(product.Id, product.Title,
                        product.TypeName, product.Description,
                        product.ImageLinks, product.Price).Item1);
                }
            }

            var models = entities.Select(x => OrderModel.CreateOrder(x.Id, x.UserId,
                PlaceModel.CreatePlace(x.Place.Id, x.Place.City, x.Place.Address).Item1, products).Item1).ToList();

            return models;
        }
        public async Task<OrderModel> GetOrderById(Guid id)
        {
            var entity = await _context.Orders
                .Include(x => x.Place)
                .Include(x => x.Products)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Order is null");

            var model = OrderModel.CreateOrder(entity.Id, entity.UserId,
                PlaceModel.CreatePlace(entity.PlaceId, entity.Place.City, entity.Place.Address).Item1,
                entity.Products.Select(x => ProductModel.CreateProduct(x.Id, x.Title, x.TypeName, x.Description, x.ImageLinks, x.Price).Item1).ToList());

            return model.Item1;
        }
        public async Task<List<OrderModel>> GetOrdersBySellerIdAsync(Guid sellerId)
        {
            var entites = await _context.Orders
                .Include(x => x.Products.Where(p => p.SellerId == sellerId))
                .Include(x => x.Place).ToListAsync();

            var models = entites
                .Select(x => OrderModel.CreateOrder(x.Id, x.UserId,
                PlaceModel.CreatePlace(x.PlaceId, x.Place.City, x.Place.Address).Item1,
                x.Products.Select(p => ProductModel.CreateProduct(p.Id, p.Title, p.TypeName, p.Description,
                p.ImageLinks, p.Price).Item1).ToList())).ToList();

            return models.Select(x => x.Item1).ToList();
        }
        public async Task<Guid> AddOrder(OrderModel model)
        {
            var entity = new OrderEntity
            {
                Id = model.Id,
                UserId = model.UserId,
                PlaceId = model.Place.Id,
                Products = model.Products.Select(x => new ProductEntity
                {
                    Id = x.Id,
                }).ToList(),
            };

            await _context.Orders.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }
        public async Task<Guid> DeleteOrder(Guid id)
        {
            _context.Orders.Remove(new OrderEntity { Id = id });
            await _context.SaveChangesAsync();

            return id;
        }
    }
}