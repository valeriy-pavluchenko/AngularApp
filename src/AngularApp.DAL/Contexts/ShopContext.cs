using AngularApp.DAL.Entities;
using AngularApp.DAL.Initializers;
using AngularApp.DAL.Interfaces;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApp.DAL.Contexts
{
    public class ShopContext : DbContext, IShopContext
    {
        public ShopContext() : base()
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Startup.Configuration["Data:AngularShopConnection:ConnectionString"]);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
