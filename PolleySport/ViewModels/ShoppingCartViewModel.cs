using System.Collections.Generic;
using PolleySport.Models;

namespace PolleySport.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}