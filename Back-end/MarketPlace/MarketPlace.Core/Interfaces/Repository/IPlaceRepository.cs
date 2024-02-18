using MarketPlace.Core.Models;

namespace MarketPlace.Core.Interfaces.Repositories
{
    public interface IPlaceRepository
    {
        Task<Guid> AddPlace(PlaceModel place);
        Task<Guid> DeletePlace(Guid id);
        Task<PlaceModel> GetPlaceById(Guid id);
        List<PlaceModel> GetPlaces();
    }
}