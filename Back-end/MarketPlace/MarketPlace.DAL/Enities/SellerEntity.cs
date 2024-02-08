using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.DAL.Enities
{
    public class SellerEntity
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
        public List<ProductEntity> Products { get; set; }
    }
}
