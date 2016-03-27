using AngularApp.BL.Interfaces;
using AngularApp.DAL.Contexts;
using AngularApp.DAL.Entities;
using AngularApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApp.BL.Providers
{
    public class CategoriesProvider : ICategoriesProvider
    {
        private IShopContext _context;

        public CategoriesProvider()
        {
            _context = new ShopContext();
        }

        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }
    }
}
