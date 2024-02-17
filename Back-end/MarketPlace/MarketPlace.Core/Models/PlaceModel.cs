using Microsoft.IdentityModel.Tokens;

namespace MarketPlace.Core.Models
{
    public class PlaceModel
    {
        private PlaceModel(Guid id, string city, string address) 
        {
            Id = id;
            City = city;
            Address = address;
        }
        public Guid Id { get; }
        public string City { get; }
        public string Address { get; }
        public static (PlaceModel, string) CreatePlace(Guid id, string city, string address)
        {
            if (city.IsNullOrEmpty() || address.IsNullOrEmpty())
                return (new PlaceModel(id, city, address), "City and address required");

            var model = new PlaceModel(id, city, address);

            return (model, string.Empty);
        }
    }
}
