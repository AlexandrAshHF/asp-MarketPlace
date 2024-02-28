namespace MarketPlace.API.Contracts.UserDTO
{
    public record class OrderModule(Guid Id, string Status, decimal Total);
    public class ProfileResponseDTO
    {
        public Guid Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public Guid? SellerId { get; set; }
        public List<OrderModule>Orders { get; set; } = new List<OrderModule>();
    }
}
