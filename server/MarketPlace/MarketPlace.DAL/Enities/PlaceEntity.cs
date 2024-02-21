namespace MarketPlace.DAL.Enities
{
    public class PlaceEntity
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public List<OrderEntity> Orders { get; set; }
    }
}
