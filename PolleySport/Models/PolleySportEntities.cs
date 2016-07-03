using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace PolleySport.Models
{
    public class PolleySportEntities : DbContext
    {
        //public DbSet<Product> Products { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<ProductAttributes> Attributes { get; set; }
        //public DbSet<Artist> Artists { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        //public DbSet<Variation> Variations { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}