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
using Serilog;

namespace CMS.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console(outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
               .CreateLogger();

            var webHost = CreateWebHostBuilder(args).Build();

            await SynchronizeDatabase(webHost);

            await webHost.RunAsync();
        }

        private static async Task SynchronizeDatabase(IWebHost webHost)
        {
            try
            {
                using (var scope = webHost.Services.CreateScope())
                {
                    var myDbContext = scope.ServiceProvider.GetRequiredService<CarsDbContext>();

                    Log.Information("Database synchronization started");

                    await myDbContext.Database.MigrateAsync();

                    Log.Information("Database synchronization finished");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Database synchronization error");
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services => services.AddAutofac())
                .UseSerilog()
                .UseStartup<Startup>();
    }
}
