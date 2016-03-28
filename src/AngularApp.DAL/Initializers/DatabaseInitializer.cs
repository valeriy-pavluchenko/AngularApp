using AngularApp.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using AngularApp.DAL.Entities;
using AngularApp.DAL.Interfaces;
using Microsoft.Data.Entity;

namespace AngularApp.DAL.Initializers
{
    /// <summary>
    /// It's habitual to use DB initializers after working with MVC 4 and 5
    /// and extremelly usefull approach for debugging purposes.
    /// </summary>
    public static class DatabaseInitializer
    {
        private static Random Random = new Random();

        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ShopContext>();
            var categoriesCount = 5;
            var productsPerCategory = 1;

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            
            if (!context.Products.Any() && !context.Categories.Any())
            {
                AddCategories(context, categoriesCount);
                AddProducts(context, productsPerCategory);
            }
        }

        private static void AddProducts(IShopContext context, int productsPerCategory)
        {
            foreach (var category in context.Categories)
            {
                for (int i = 0; i < productsPerCategory; i++)
                {
                    context.Products.Add(
                        new Product
                        {
                            Name = $"Product {i}.{category.Id}",
                            Price = Random.Next(50, 1000),
                            Description = $"Description {i}.{category.Id}",
                            IsAvailable = Random.Next(0, 100) > 50 ? true : false,
                            CategoryId = category.Id
                        });
                }
            }

            context.SaveChanges();
        }

        public static void AddCategories(IShopContext context, int categoriesCount)
        {
            for (int i = 0; i < categoriesCount; i++)
            {
                context.Categories.Add(
                    new Category
                    {
                        Name = $"Category {i}"
                    });
            }

            context.SaveChanges();
        }
    }
}
