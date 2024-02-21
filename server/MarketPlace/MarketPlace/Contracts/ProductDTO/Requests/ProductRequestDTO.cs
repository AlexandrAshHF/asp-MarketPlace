namespace MarketPlace.API.Contracts.ProductDTO.Requests
{
    public class ProductRequestDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? TypeName { get; set; }
        public string Description { get; set; }
        public List<string> ImageLinks { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
    }
}
