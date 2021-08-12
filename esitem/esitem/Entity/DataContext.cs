using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace esitem.Entity
{
    public class DataContext:DbContext
    {
        public DataContext():base("dataConnection")
        {
          Database.SetInitializer(new DataIntializer()); 
        }

        public DbSet<Ürün> Ürüns { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public IEnumerable<object> UserProfile { get; internal set; }
    }
}