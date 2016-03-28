using AngularApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApp.BL.Interfaces
{
    public interface IProductsProvider
    {
        List<Product> GetAllProducts();
        Product GetProduct(int id);
        List<Product> GetProductsByCategory(int categoryId);
        Product AddProduct(Product product);
        Product UpdateProduct(Product product);
        void RemoveProduct(Product product);
    }
}
