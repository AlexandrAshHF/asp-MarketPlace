using Microsoft.IdentityModel.Tokens;

namespace MarketPlace.Core.Models
{
    public class CategoryModel
    {
        public const int MAX_LENGTH_TITLE = 50;
        public const int MAX_NUMBER_CHARACTERISTICS = 10;
        public CategoryModel(Guid id, string title, List<CategoryModel>? categories, CategoryModel? parrent,
            List<ProductModel>? products, List<string>characteristics)
        {
            Id = id;
            Title = title;
            SubCategories = categories;
            ParrentCategory = parrent;
            Products = products;
            Characteristics = characteristics;
        }
        public Guid Id { get; }
        public string Title { get; }
        public List<CategoryModel>? SubCategories { get; }
        public CategoryModel? ParrentCategory { get; }
        public List<ProductModel>? Products { get; }
        public List<string> Characteristics { get; }
        public static (CategoryModel, string) CreateCategory(Guid id, string title, List<CategoryModel>? categories, CategoryModel? parrent,
            List<ProductModel>? products, List<string> characteristics)
        {
            string errorMessege = string.Empty;

            if (title.IsNullOrEmpty() || title.Length > MAX_LENGTH_TITLE)
                errorMessege = $"Title cannot be empty and longer than {MAX_LENGTH_TITLE} characters";

            if (characteristics.Count == 0 || characteristics.Count > MAX_NUMBER_CHARACTERISTICS)
                errorMessege = $"Category should includes more zero characteristics and little {MAX_NUMBER_CHARACTERISTICS}";

            var category = new CategoryModel(id, title, categories, parrent, products, characteristics);

            return (category, errorMessege);
        }
    }
}
