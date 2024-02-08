namespace MarketPlace.DAL.Enities
{
    public class CategoryEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<CategoryEntity>?SubCategories { get; set; }
        public Guid? ParrentId { get; set; }
        public CategoryEntity? ParrentCategory { get; set; }
        public List<ProductEntity>? Products { get; set; }
        public List<string> Characteristics { get; set; }
    }
}
