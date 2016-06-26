using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace PolleySport.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }
        
        public int Stock { get; set; }

        public decimal ShippingCost { get; set; }

        public int CategoryId { get; set; }

        //public int SubCategoryId { get; set; }

        public virtual CategoryModel Category { get; set; }
        public virtual SubCategoryModel SubCategory { get; set; }
        public virtual List<ProductAttributesModel> Attributes {get; set;}
    }
}