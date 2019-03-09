using Autofac;
using CMS.Cars.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CMS.Cars.Application
{
    public class CarsModule : Autofac.Module
    {
        public IConfiguration Configuration { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var opt = new DbContextOptionsBuilder<CarsDbContext>();
                opt.UseSqlServer(Configuration.GetValue<string>("ConnectionStrings:CarsDbConnectionString"));

                return new CarsDbContext(opt.Options);
            }).AsSelf().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(ApplicationProjectMarker).Assembly)
                .Where(service =>
                    service.Name.EndsWith("CommandHandler") ||
                    service.Name.EndsWith("QueryHandler"))
                .AsImplementedInterfaces();

            var configuration = new Configuration()
            {
                ApproachingExpirationDaysBefore = Configuration.GetValue<int>("ApproachingExpirationDaysBefore")
            };

            builder.RegisterInstance(configuration).AsSelf();
        }
    }
}
