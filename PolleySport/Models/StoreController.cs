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

        public ActionResult Browse(string subGenre)// genre)
        {
            // Retrieve Genre and its Associated Albums from database
            //var genreModel = storeDB.Categorys.Include("Albums")
            //.Single(g => g.CategoryName == genre);
            var genreModel = storeDB.SubCategories.Include("Albums")
                .Single(g => g.SubCategoryName == subGenre);

            return View(genreModel);
        }

        //
        // GET: /Store/Details/5

        public ActionResult Details(int id)
        {
            var product = storeDB.Products.Find(id);

            return View(product);
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
