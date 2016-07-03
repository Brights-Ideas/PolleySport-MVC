using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PolleySport.Models
{
    public class SubCategory
    {
        [Key]
        public int SubCategoryId { get; set; }

        public string SubCategoryName { get; set; }

        //[ForeignKey]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public virtual List<Products> Products { get; set; }
    }
}