using MarketPlace.Core.Models;

namespace MarketPlace.Core.Interfaces.DataIntefaces
{
    public interface IPlacesService
    {
        Task<(Guid, string)> AddPlace(Guid id, string city, string address);
        Task<Guid> DeletePlace(Guid id);
        Task<PlaceModel> GetPlaceById(Guid id);
        List<PlaceModel> GetPlaces();
        Task<(Guid, string)> UpdatePlace(Guid id, string city, string address);
    }
}