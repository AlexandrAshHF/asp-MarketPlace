namespace MarketPlace.Core.Models
{
    public class UserModel
    {
        public const int MAX_LENGTH_USERNAME = 24;
        public const int MIN_LENGTH_USERNAME = 6;
        public UserModel(Guid id, string um, string email, bool emailConf, string passHash, string role)
        {
            Id = id;
            Username = um;
            Email = email;
            EmailConfirm = emailConf;
            PasswordHash = passHash;
            Role = role;
        }
        public Guid Id { get; }
        public string Username { get; }
        public string Email { get; }
        public bool EmailConfirm { get; }
        public string PasswordHash { get; }
        public string Role { get; }
        public static (UserModel, string) CreateUser(Guid id, string um, string email, bool emailConf, string passHash, string role)
        {
            string errorMessege = string.Empty;

            if (um.Length > MAX_LENGTH_USERNAME || um.Length < MIN_LENGTH_USERNAME)
                errorMessege = "Username length caannot be longer than 24 characters and shorter than 6 characters";

            //verify email

            var user = new UserModel(id, um, email, emailConf, passHash, role);

            return (user, errorMessege);
        }
    }
}
