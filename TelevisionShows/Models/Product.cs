using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelevisionShows.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

    public class Cart
    {
        public List<CartItem> CartItems { get; set; }
    }
}
