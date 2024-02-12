using MarketPlace.Core.Models;

namespace MarketPlace.Core.Interfaces.DataIntefaces
{
    public interface ICategoryService
    {
        Task<(Guid, string)> AddCategoryAsync(Guid id, string title, List<string> characteristics, Guid parrentId);
        Task<Guid> DeleteCategoryAsync(Guid id);
        Task<CategoryModel?> GetCategoryByIdAsync(Guid id);
        Task<List<CategoryModel>> GetChildrenByIdAsync(Guid? id);
        List<CategoryModel> GetParrentUpCategories();
        Task<(Guid, string)> UpdateCategoryAsync(Guid id, string title, List<string> characteristics, Guid parrentId);
    }
}