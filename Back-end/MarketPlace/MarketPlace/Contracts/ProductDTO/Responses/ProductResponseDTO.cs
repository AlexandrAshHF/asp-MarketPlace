namespace MarketPlace.API.Contracts.ProductDTO.Responses
{
    public class ProductResponseDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public string ImageLinks { get; set; }
        public decimal Price { get; set; }
    }
}
