using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelevisionShows.Models;
using static TelevisionShows.Models.ExtensionMethods;

namespace TelevisionShows.Controllers
{
    public class HomeController : Controller
    {

        //public async Task<ViewResult> Index()
        //{
        //    var uri = "http://www.campus.varnamo.se/";
        //    long? length = await HeavyMethods.CalculatePageSize(uri);

        //    return View(new string[] { $"Content length of: {uri} is {length}." });
        //}

        public IActionResult Index()
        {
            var shows = Show.GetShows();
            var list = new List<string>();

            foreach (var show in shows)
            {
                if (ShowIsLegit(show))
                    list.Add(string.Format("Show {0} has an Imdb rating of {1}.", show?.Name, show?.ImdbRating));
            }

            return View(list);
        }

        public bool ShowIsLegit(Show show)
        {
            if (show == null) return false;
            if (string.IsNullOrEmpty(show.Name)) return false;

            return true;
        }

        public IActionResult CheckoutCartExample()
        {
            var p1 = new Product { Id = 1, Name = "Duffel bag 37L", Price = 399 };
            var p2 = new Product { Id = 2, Name = "Hiking shoes", Price = 1255 };
            var p3 = new Product { Id = 3, Name = "Fishing rod", Price = 999 };
            var listOfProducts = new List<Product> { p1, p2, p3 };

            var filtered = listOfProducts.FilterByPrice();
            var filtered2 = listOfProducts.FilterByPrice(400, 1000);
            var byFirstLetter = listOfProducts.ProductNameBeginsWith("D");

            var cartItem1 = new CartItem { Product = p1, Quantity = 2 };
            var cartItem2 = new CartItem { Product = p2, Quantity = 5 };
            var cartItem3 = new CartItem { Product = p3, Quantity = 1 };

            var cart = new Cart { CartItems = new List<CartItem> { cartItem1, cartItem2, cartItem3 } };

            //return View("Index", listOfProducts);
            return View("Index", cart);
        }

        
    }
}
