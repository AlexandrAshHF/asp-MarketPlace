﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.DAL.Enities
{
    public class ProductEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public List<string>ImageLinks { get; set; }
        public decimal Price { get; set; }
        public Guid SellerId { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryEntity CategoryEntity { get; set; }
        public List<ReviewEntity>Reviews { get; set; }
    }
}
