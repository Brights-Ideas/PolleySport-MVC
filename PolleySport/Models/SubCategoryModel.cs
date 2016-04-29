using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PolleySport.Models
{
    public class SubCategoryModel
    {
        [Key]
        public int SubCategoryId { get; set; }

        public string SubCategoryName { get; set; }

        //[ForeignKey]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        //public virtual List<ProductModel> Products { get; set; }
    }
}