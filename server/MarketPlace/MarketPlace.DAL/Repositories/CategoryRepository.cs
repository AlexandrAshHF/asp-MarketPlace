using MarketPlace.Core.Interfaces.Repositories;
using MarketPlace.Core.Models;
using MarketPlace.DAL.Enities;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationContext _context;
        public CategoryRepository(ApplicationContext context)
        {
            _context = context;
        }
        public List<CategoryModel> GetParrentUpCategories()
        {
            List<CategoryModel>? models = new List<CategoryModel>();
            var entities = _context.Categories.Where(x => x.ParrentCategory == null);

            foreach (var item in entities)
                models.Add(CategoryModel.CreateCategory(item.Id, item.Title, item.Characteristics).Item1);

            return models;
        }
        public async Task<CategoryModel?> GetCategoryByIdAsync(Guid id)
        {
            var entity = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (entity == null)
                return null;

            var model = CategoryModel.CreateCategory(id, entity.Title, entity.Characteristics).Item1;

            return model;
        }
        public async Task<List<CategoryModel>?> GetChildrenByIdAsync(Guid? id)
        {
            List<CategoryModel>? models = new List<CategoryModel>();

            var entities = await _context.Categories.Include(x => x.SubCategories)
                                              .FirstOrDefaultAsync(x => x.Id == id);

            if (entities == null || entities.SubCategories == null)
                return null;

            foreach (var item in entities.SubCategories)
                models.Add(CategoryModel.CreateCategory(item.Id, item.Title, item.Characteristics).Item1);

            return models;
        }
        public async Task<Guid> AddCategoryAsync(CategoryModel category, Guid parrentId)
        {
            var entity = new CategoryEntity
            {
                Id = category.Id,
                Title = category.Title,
                Characteristics = category.Characteristics,
                ParrentId = parrentId,
                Products = new List<ProductEntity>(),
                SubCategories = new List<CategoryEntity>(),
            };

            await _context.Categories.AddAsync(entity);
            await _context.SaveChangesAsync();

            return category.Id;
        }
        public async Task<Guid> UpdateCategoryAsync(CategoryModel category, Guid parrentId)
        {
            var entity = new CategoryEntity
            {
                Id = category.Id,
                Title = category.Title,
                Characteristics = category.Characteristics,
                ParrentId = parrentId,
                Products = new List<ProductEntity>(),
                SubCategories = new List<CategoryEntity>(),
            };

            _context.Categories.Update(entity);
            await _context.SaveChangesAsync();

            return category.Id;
        }
        public async Task<Guid> DeleteCategoryAsync(Guid id)
        {
            _context.Remove(new CategoryEntity { Id = id });
            await _context.SaveChangesAsync();

            return id;
        }
    }
}