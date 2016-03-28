using AngularApp.BL.Interfaces;
using AngularApp.BL.Providers;
using AngularApp.DAL.Entities;
using AngularApp.PL.Models.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApp.PL.Models
{
    public static class Mapper
    {
        public static ProductViewModel ToViewModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                IsAvailable = product.IsAvailable,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name
            };
        }

        public static Product ToDataModel(ProductViewModel product)
        {
            return new Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                IsAvailable = product.IsAvailable,
                CategoryId = product.CategoryId
            };
        }

        public static List<ProductViewModel> ToViewModel(List<Product> products)
        {
            var productsView = new List<ProductViewModel>();

            foreach (var product in products)
            {
                productsView.Add(ToViewModel(product));
            }

            return productsView;
        }

        public static List<Product> ToDataModel(List<ProductViewModel> products)
        {
            var productsData = new List<Product>();

            foreach (var product in products)
            {
                productsData.Add(ToDataModel(product));
            }

            return productsData;
        }

        public static CategoryViewModel ToViewModel(Category category)
        {
            return new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public static Category ToDataModel(CategoryViewModel category)
        {
            return new Category
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        //public static List<CategoryViewModel> ToViewModel(List<Category> categories)
        //{
        //    foreach (var category in categories)
        //    {
        //        yield return ToViewModel(category);
        //    }
        //}

        //public static List<Category> ToDataModel(List<CategoryViewModel> categories)
        //{
        //    foreach (var category in categories)
        //    {
        //        yield return ToDataModel(category);
        //    }
        //}
    }
}
