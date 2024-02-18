using MarketPlace.Core.Interfaces.Repositories;
using MarketPlace.Core.Models;
using MarketPlace.DAL.Enities;

namespace MarketPlace.DAL.Repositories
{
    public class PlaceRepository : IPlaceRepository
    {
        private ApplicationContext _context;
        public PlaceRepository(ApplicationContext context)
        {
            _context = context;
        }
        public List<PlaceModel> GetPlaces()
        {
            var models = _context.Places.Select(x => PlaceModel.CreatePlace(x.Id, x.City, x.Address).Item1).ToList();
            return models;
        }
        public async Task<PlaceModel> GetPlaceById(Guid id)
        {
            var entity = await _context.Places.FindAsync(id);

            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "PlaceEntity by id is null");

            return PlaceModel.CreatePlace(entity.Id, entity.City, entity.Address).Item1;
        }
        public async Task<Guid> AddPlace(PlaceModel place)
        {
            var entity = new PlaceEntity
            {
                Id = place.Id,
                City = place.City,
                Address = place.Address,
            };

            await _context.Places.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }
        public async Task<Guid> DeletePlace(Guid id)
        {
            _context.Places.Remove(new PlaceEntity { Id = id });
            await _context.SaveChangesAsync();

            return id;
        }
    }
}