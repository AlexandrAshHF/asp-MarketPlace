namespace MarketPlace.Core.Models
{
    public class OrderModel
    {
        private OrderModel(Guid id, Guid userId, PlaceModel place, List<ProductModel> products)
        {
            Id = id;
            UserId = userId;
            Place = place;
            Products = products;
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public PlaceModel Place { get; set; }
        public List<ProductModel> Products { get; set; }
        public static (OrderModel, string) CreateOrder(Guid id, Guid userId, PlaceModel place, List<ProductModel> products)
        {
            var model = new OrderModel(id, userId, place, products);
            return (model, string.Empty);
        }
    }
}
