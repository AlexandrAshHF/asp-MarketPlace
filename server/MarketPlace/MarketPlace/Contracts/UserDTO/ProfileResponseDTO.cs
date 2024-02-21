namespace MarketPlace.API.Contracts.UserDTO
{
    public class ProfileResponseDTO
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool EmailConfirm { get; set; }
        public string? SellerId { get; set; }
    }
}
