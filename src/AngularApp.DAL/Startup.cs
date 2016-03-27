using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AngularApp.DAL.Contexts;
using Microsoft.Data.Entity;
using AngularApp.DAL.Initializers;

namespace AngularApp.DAL
{
    public class Startup
    {
        public static IConfigurationRoot Configuration { get; set; }

        static Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services, IApplicationBuilder app)
        {
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ShopContext>(options =>
                    options.UseSqlServer(Configuration["Data:AngularShopConnection:ConnectionString"]));
        }

        public void Configure(IApplicationBuilder app)
        { }
    }
}
