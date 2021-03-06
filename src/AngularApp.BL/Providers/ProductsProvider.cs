﻿using AngularApp.BL.Interfaces;
using AngularApp.DAL.Entities;
using AngularApp.DAL.Interfaces;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApp.BL.Providers
{
    public class ProductsProvider : IProductsProvider
    {
        private IShopContext _context;

        public ProductsProvider(IShopContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products
                .Include(p => p.Category)
                .ToList();
        }

        public Product GetProduct(int id)
        {
            return _context.Products
                .Where(p => p.Id == id)
                .Include(p => p.Category)
                .SingleOrDefault();
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _context.Products
                .Where(p => p.CategoryId == categoryId)
                .ToList();
        }

        public Product AddProduct(Product product)
        {
            _context.Products.Add(product);

            _context.SaveChanges();
            return product;
        }

        public Product UpdateProduct(Product product)
        {
            var entry = _context.Entry(product);
            entry.State = EntityState.Modified;

            _context.SaveChanges();
            return product;
        }

        public void RemoveProduct(Product product)
        {
            var entry = _context.Entry(product);
            entry.State = EntityState.Deleted;

            _context.SaveChanges();
        }
    }
}
