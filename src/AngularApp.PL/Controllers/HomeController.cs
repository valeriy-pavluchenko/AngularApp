using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using AngularApp.DAL.Contexts;
using AngularApp.BL.Interfaces;
using AngularApp.BL.Providers;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AngularApp.Controllers
{
    public class HomeController : Controller
    {
        private ICategoriesProvider _categoriesProvider;
        private IProductsProvider _productsProvider;

        public HomeController()
        {
            _categoriesProvider = new CategoriesProvider();
            _productsProvider = new ProductsProvider();
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            int count = 0;

            using (var context = new ShopContext())
            {
                count = context.Products.ToList().Count;
            }

            ViewBag.Temp = count;
            ViewBag.N1 = _categoriesProvider.GetAllCategories();
            ViewBag.N2 = _productsProvider.GetAllProducts();

            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
