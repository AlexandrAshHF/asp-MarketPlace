namespace MarketPlace.DAL.Enities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool EmailConfirm { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
    }
}
