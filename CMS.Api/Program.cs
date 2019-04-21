using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using Microsoft.Extensions.DependencyInjection;
using CMS.Cars.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CMS.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var webHost = CreateWebHostBuilder(args).Build();
           
            using (var scope = webHost.Services.CreateScope())
            {                
                var myDbContext = scope.ServiceProvider.GetRequiredService<CarsDbContext>();
               
                await myDbContext.Database.MigrateAsync();
            }
            
            await webHost.RunAsync();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services => services.AddAutofac())
                .UseStartup<Startup>();
    }
}
