using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace esitem.Entity
{
    public class Ürün
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description  { get; set; }
        public string İmage { get; set; }

        public double Price { get; set; }
        public int Stock { get; set; }
        public bool Slider { get; set; }
        public bool IsHome { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsApproved { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}