namespace MarketPlace.Core.Models
{
    public class SellerModel
    {
        public SellerModel(Guid id, string pn, UserModel user)
        {
            Id = id;
            PhoneNumber = pn;
            User = user;
        }
        public Guid Id { get; }
        public string PhoneNumber { get; }
        public UserModel User { get; }
        public static (SellerModel, string) CreateSeller(Guid id, string pn, UserModel user)
        {
            string errorMessege = string.Empty;

            //Check phone numeber here

            SellerModel seller = new SellerModel(id, pn, user);

            return (seller, errorMessege);
        }
    }
}
