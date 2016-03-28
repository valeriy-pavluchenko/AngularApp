using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using AngularApp.BL.Interfaces;
using AngularApp.BL.Providers;
using AngularApp.PL.Models.Shop;
using AngularApp.PL.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AngularApp.PL.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private ICategoriesProvider _categoriesProvider;
        private IProductsProvider _productsProvider;

        public ProductController()
        {
            _categoriesProvider = new CategoriesProvider();
            _productsProvider = new ProductsProvider();
        }

        [HttpGet]
        public List<ProductViewModel> Get()
        {
            var result = Mapper.ToViewModel(_productsProvider.GetAllProducts());

            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ProductViewModel Get(int id)
        {
            return Mapper.ToViewModel(_productsProvider.GetProduct(id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]ProductViewModel product)
        {
            var productData = Mapper.ToDataModel(product);
            _productsProvider.AddProduct(productData);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
