namespace MarketPlace.API.Contracts.CategoryDTO
{
    public class CategoryRequestDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<string> Characteristics { get; set; }
        public Guid ParrentId { get; set; }
    }
}
