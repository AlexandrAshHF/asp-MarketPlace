using MarketPlace.Core.Interfaces.DataIntefaces;
using MarketPlace.Core.Interfaces.Repositories;
using MarketPlace.Core.Models;
using Microsoft.IdentityModel.Tokens;

namespace MarketPlace.Application.Services
{
    public class CategoriesService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public CategoriesService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<(Guid, string)> AddCategoryAsync(Guid id, string title, List<string> characteristics, Guid parrentId)
        {
            var model = CategoryModel.CreateCategory(id, title, characteristics, parrentId);

            if (!model.Item2.IsNullOrEmpty())
                return (id, model.Item2);

            return (await _categoryRepository.AddCategoryAsync(model.Item1, parrentId), string.Empty);
        }
        public async Task<Guid> DeleteCategoryAsync(Guid id)
        {
            return await _categoryRepository.DeleteCategoryAsync(id);
        }
        public async Task<CategoryModel?> GetCategoryByIdAsync(Guid id)
        {
            return await _categoryRepository.GetCategoryByIdAsync(id);
        }
        public async Task<List<CategoryModel>> GetChildrenByIdAsync(Guid? id)
        {
            var models = await _categoryRepository.GetChildrenByIdAsync(id);

            if (models.IsNullOrEmpty())
                return new List<CategoryModel>();

            return models;
        }
        public async Task<(Guid, string)> UpdateCategoryAsync(Guid id, string title, List<string> characteristics, Guid parrentId)
        {
            var model = CategoryModel.CreateCategory(id, title, characteristics, parrentId);

            if (!model.Item2.IsNullOrEmpty())
                return (id, model.Item2);

            return (await _categoryRepository.AddCategoryAsync(model.Item1, parrentId), string.Empty);
        }
        public List<CategoryModel> GetParrentUpCategories()
        {
            return _categoryRepository.GetParrentUpCategories();
        }
        public List<CategoryModel>GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }
    }
}
