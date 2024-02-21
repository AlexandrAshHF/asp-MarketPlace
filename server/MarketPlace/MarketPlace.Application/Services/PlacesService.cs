using MarketPlace.Core.Interfaces.DataIntefaces;
using MarketPlace.Core.Interfaces.Repositories;
using MarketPlace.Core.Models;
using Microsoft.IdentityModel.Tokens;

namespace MarketPlace.Application.Services
{
    public class PlacesService : IPlacesService
    {
        private IPlaceRepository _placeRepository;
        public PlacesService(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        public async Task<(Guid, string)> AddPlace(Guid id, string city, string address)
        {
            var model = PlaceModel.CreatePlace(id, city, address);

            if (!model.Item2.IsNullOrEmpty())
                return (Guid.Empty, model.Item2);

            var result = await _placeRepository.AddPlace(model.Item1);
            return (result, string.Empty);
        }
        public async Task<Guid> DeletePlace(Guid id)
        {
            return await _placeRepository.DeletePlace(id);
        }
        public async Task<PlaceModel> GetPlaceById(Guid id)
        {
            return await _placeRepository.GetPlaceById(id);
        }
        public List<PlaceModel> GetPlaces()
        {
            return _placeRepository.GetPlaces();
        }
        public async Task<(Guid, string)> UpdatePlace(Guid id, string city, string address)
        {
            var model = PlaceModel.CreatePlace(id, city, address);

            if (!model.Item2.IsNullOrEmpty())
                return (Guid.Empty, model.Item2);

            var result = await _placeRepository.UpdatePlace(model.Item1);
            return (result, string.Empty);
        }
    }
}