using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PolleySport.Models;

namespace PolleySport.Controllers
{
    public class HomeController : Controller
    {
        PolleySportEntities storeDB = new PolleySportEntities();

        public ActionResult Index()
        {
            // Get most popular products
            var products = GetTopSellingProducts(5);

            return View(products);
        }

        private List<ProductModel> GetTopSellingProducts(int count)
        {
            // Group the order details by album and return
            // the products with the highest count

            return storeDB.Products
                //.OrderByDescending(a => a.OrderDetails.Count())
                .Take(count)
                .ToList();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
