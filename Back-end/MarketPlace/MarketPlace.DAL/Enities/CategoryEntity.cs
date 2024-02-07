using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.DAL.Enities
{
    public class CategoryEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<CategoryEntity>?SubCategories { get; set; }
        public List<ProductEntity>? Products { get; set; }
        public Dictionary<string, string> Characteristics { get; set; }
    }
}
