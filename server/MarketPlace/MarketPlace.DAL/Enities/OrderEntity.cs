namespace MarketPlace.DAL.Enities
{
    public class OrderEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
        public Guid PlaceId { get; set; }
        public PlaceEntity? Place { get; set; }
        public List<ProductEntity> Products { get; set; }
    }
}
