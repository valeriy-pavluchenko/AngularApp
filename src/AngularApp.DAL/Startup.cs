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
    /// <summary>
    /// This configuration class has some code doubling in comparison with same class from PL.
    /// This has been used for allowing adding migrations to the DAL library (the same as adding
    /// appsettings.json to this library and use Startup.Configuration in ShopContext)
    /// 
    /// For enabling cmd commands defined in project.json you should execute command via win cmd: dnvm use 1.0.0-rc1-final
    /// After it install to the project.DAL the latest version of ASP.NET Core CLR using win cmd: dnvm install latest -r coreclr
    /// Then you can add migration to the project.DAL class library using win cmd: dnx ef migrations add MigrationName
    /// As final step, to update database to last migration: dnx ef database update
    /// 
    /// However, implementing a database initializer allows to avoid much annoiyng actions.
    /// </summary>
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
