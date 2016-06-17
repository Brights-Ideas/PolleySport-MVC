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
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CategoryModel> Categorys { get; set; }
        public DbSet<SubCategoryModel> SubCategories { get; set; }
        public DbSet<ProductAttributesModel> Attributes { get; set; }
        //public DbSet<Artist> Artists { get; set; }
        public DbSet<Cart> Carts { get; set; }
        //public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        //public DbSet<Variation> Variations { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}