namespace MarketPlace.API.Contracts.ProductDTO.Responses
{
    public class SelectedProductResponseDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? TypeName { get; set; }
        public string Description { get; set; }
        public List<string> ImageLinks { get; set; }
        public decimal Price { get; set; }
    }
}
