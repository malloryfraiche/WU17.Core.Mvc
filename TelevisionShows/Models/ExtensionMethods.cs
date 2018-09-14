using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TelevisionShows.Models
{
    public static class ExtensionMethods
    {
        public static decimal CartTotal(this Cart cart)
        {
            decimal total = 0;
            foreach (var cartItem in cart.CartItems)
            {
                var productPrice = cartItem.Product.Price;
                var qty = cartItem.Quantity;
                var cartItemTotal = productPrice + qty;
                total += cartItemTotal;
            }
            return total;
        }

        public static IEnumerable<Product> FilterByPrice(this IEnumerable<Product> products, decimal minPrice = 0, decimal maxPrice = decimal.MaxValue)
        {
            // Extension Methods should be static. Need to have 'yield' for it to work.
            foreach(var p in products)
            {
                if(p.Price >= minPrice && p.Price <= maxPrice)
                {
                    yield return p;
                }
            }
        }

        public static IEnumerable<Product> ProductNameBeginsWith(this IEnumerable<Product> products, string firstLetter)
        {
            foreach (var p in products)
            {
                if (p.Name.StartsWith(firstLetter))
                {
                    yield return p;
                }
            }
        }


        public class HeavyMethods
        {
            public async static Task<long?> CalculatePageSize(string uri)
            {
                var client = new HttpClient();
                var httpReq = await client.GetAsync(uri);

                return httpReq.Content.Headers.ContentLength;
            }
        }

    }
}
