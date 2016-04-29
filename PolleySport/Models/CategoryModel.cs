using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace PolleySport.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        //public virtual SubCategoryModel SubCategory { get; set; }
        public virtual ICollection<SubCategoryModel> SubCategories { get; set; }
    }
}