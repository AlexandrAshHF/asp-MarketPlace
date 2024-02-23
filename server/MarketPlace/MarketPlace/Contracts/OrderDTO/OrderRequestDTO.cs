namespace MarketPlace.API.Contracts.OrderDTO
{
    public class OrderRequestDTO
    {
        public Guid placeId { get; set; }
        public List<Guid> productsId {  get; set; }
    }
}
