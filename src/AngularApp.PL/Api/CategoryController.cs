using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using AngularApp.BL.Interfaces;
using AngularApp.PL.Models.Shop;
using AngularApp.PL.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AngularApp.PL.Api
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private ICategoriesProvider _categoriesProvider;

        public CategoryController(ICategoriesProvider categoriesProvider)
        {
            _categoriesProvider = categoriesProvider;
        }

        [HttpGet]
        public List<CategoryViewModel> Get()
        {
            var result = Mapper.ToViewModel(_categoriesProvider.GetAllCategories());

            return result;
        }

        [HttpGet("{id}")]
        public CategoryViewModel Get(int id)
        {
            return Mapper.ToViewModel(_categoriesProvider.GetCategory(id));
        }
    }
}
