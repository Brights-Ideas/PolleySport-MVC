using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PolleySport.Models
{
    public class StoreController : Controller
    {
        PolleySportEntities storeDB = new PolleySportEntities();

        //
        // GET: /Store/

        public ActionResult Index()
        {
            var categories = storeDB.Categorys.ToList();

            return View(categories);
        }

        //
        // GET: /Store/Browse?genre=Disco

        public ActionResult Browse(int? SubCategoryId)
        {
            // Retrieve Genre and its Associated Albums from database
            var categoryModel = storeDB.SubCategories.Include("Products")
                .Single(g => g.SubCategoryId == SubCategoryId);
            //var genreModel = storeDB.Categorys.Include("Albums")
            //.Single(g => g.CategoryName == genre);
            //var genreModel = storeDB.SubCategories.Include("Products")
                //.Single(g => g.SubCategoryName == subGenre);

            return View(categoryModel);
        }

        //
        // GET: /Store/Details/5

        public ActionResult Details(int id)
        {
            var product = storeDB.Products.Find(id);

            return View(product);
        }

        public decimal GetProductPrice(int variationId)
        {
            var varia = storeDB.Attributes.Find(variationId);

            return varia.Price;
        }

        //
        // GET: /Store/PrimaryMenu

        [ChildActionOnly]
        public ActionResult _PrimaryMenu()
        {
            var categories = storeDB.Categorys.ToList();

            //var subGenres = storeDB.SubCategories.ToList();

            return PartialView(categories);
        }

    }
}
