namespace MarketPlace.API.Contracts.PlaceDTO
{
    public class PlaceRequestDTO
    {
        public Guid? Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}
