using System.ComponentModel.DataAnnotations;

namespace PolleySport.Models
{
    public class Cart
    {
        [Key]
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public System.DateTime DateCreated { get; set; }

        public decimal ProductAttributesPrice { get; set; }
        public virtual ProductModel Product { get; set; }
    }
}