using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using AngularApp.DAL.Contexts;
using Microsoft.Data.Entity;
using AngularApp.DAL.Initializers;
using AngularApp.BL.Interfaces;
using AngularApp.BL.Providers;
using AngularApp.DAL.Interfaces;

namespace AngularApp.PL
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public Startup()
        {
            // Adding configuration file for reading necessary data
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Add Entity Framework and configure it
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ShopContext>(options =>
                    options.UseSqlServer(Configuration["Data:AngularShopConnection:ConnectionString"]));

            // Add MVC support to the project
            services.AddMvc();

            // Add dependency injection
            services.AddTransient<IShopContext, ShopContext>();
            services.AddTransient<ICategoriesProvider, CategoriesProvider>();
            services.AddTransient<IProductsProvider, ProductsProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            // Initializing database with test values
            DatabaseInitializer.Initialize(app.ApplicationServices);

            // Using library for debug notes on web interface
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();

            // Configuring default routes
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // Allow to use static files (for example, styles and scripts from wwwroot)
            app.UseStaticFiles();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
