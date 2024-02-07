using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.DAL.Enities
{
    public class ReviewEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Text { get; set; }
        public double Rating { get; set; }
        public DateTime DateOfCreate { get; set; }
    }
}
