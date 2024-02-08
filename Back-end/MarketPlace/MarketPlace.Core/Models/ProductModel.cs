using Microsoft.IdentityModel.Tokens;

namespace MarketPlace.Core.Models
{
    public class ProductModel
    {
        public const int MAX_LENGTH_TITLE = 75;
        public const int MAX_LENGTH_DESC = 500;
        public ProductModel(Guid id, string title, string? typeName, string desc, List<string>imgList, decimal price) 
        {
            Id = id;
            Title = title;
            TypeName = typeName;
            Description = desc;
            ImageLinks = imgList;
            Price = price;
        }
        public Guid Id { get; }
        public string Title { get; }
        public string? TypeName { get; }
        public string Description { get; }
        public List<string> ImageLinks { get; }
        public decimal Price { get; }
        public static (ProductModel, string) CreateProduct(Guid id, string title, string? typeName, string desc, List<string> imgList, decimal price)
        {
            string errorMessege = string.Empty;

            if (title.IsNullOrEmpty() || title.Length > MAX_LENGTH_TITLE)
                errorMessege = $"Title cannot be longer {MAX_LENGTH_TITLE} characters and cannot be empty";

            if (desc.IsNullOrEmpty() || desc.Length > MAX_LENGTH_DESC)
                errorMessege = $"Description cannot be longer {MAX_LENGTH_DESC} characters and cannot be empty";

            var product = new ProductModel(id, title, typeName, desc, imgList, price);

            return (product, errorMessege);
        }
    }
}