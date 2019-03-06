using Autofac;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Cars.Application
{
    public class CarsModule : Module
    {
        public IConfiguration Configuration { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(service =>
                    service.Name.EndsWith("CommandHandler") ||
                    service.Name.EndsWith("QueryHandler"))
                .AsImplementedInterfaces();

            var configuration = new Configuration()
            {
                ApproachingExpirationDaysBefore = Configuration.GetValue<int>("WarnAboutApproachingExpirationDaysBefore")
            };

            builder.RegisterInstance(configuration).AsSelf();
        }
    }
}
