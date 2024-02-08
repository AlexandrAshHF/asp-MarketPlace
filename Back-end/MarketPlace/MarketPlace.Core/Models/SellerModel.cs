namespace MarketPlace.Core.Models
{
    public class SellerModel
    {
        public SellerModel(Guid id, string pn, UserModel user, List<ProductModel>pmList) 
        { 
            Id = id;
            PhoneNumber = pn;
            User = user;
            Products = pmList;
        }
        public Guid Id { get; }
        public string PhoneNumber { get; }
        public UserModel User { get; }
       public List<ProductModel> Products { get; }
        public static (SellerModel, string) CreateSeller(Guid id, string pn, UserModel user, List<ProductModel>pmList)
        {
            string errorMessege = string.Empty;

            //Check phone numeber here

            SellerModel seller = new SellerModel(id, pn, user, pmList);

            return (seller, errorMessege);
        }
    }
}
