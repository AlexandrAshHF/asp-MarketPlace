using MarketPlace.Core.Models;

namespace MarketPlace.Core.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<Guid> AddCategoryAsync(CategoryModel category, Guid parrentId);
        Task<Guid> DeleteCategoryAsync(Guid id);
        Task<CategoryModel?> GetCategoryByIdAsync(Guid id);
        Task<List<CategoryModel>?> GetChildrenByIdAsync(Guid? id);
        Task<Guid> UpdateCategoryAsync(CategoryModel category, Guid parrentId);
        List<CategoryModel> GetParrentUpCategories();
        List<CategoryModel> GetAllCategories();
    }
}