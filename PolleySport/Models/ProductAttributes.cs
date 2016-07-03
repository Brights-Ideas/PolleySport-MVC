using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PolleySport.Models
{
    public class ProductAttributes
    {
        [Key]
        public int AttributeId { get; set; }

        //public string Name { get; set; }

        public string Value { get; set; }

        public decimal Price { get; set; }

        public int? ProductId { get; set; }
    }
}