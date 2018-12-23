using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Cars.Application
{
    public class CarsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(service => 
                    service.Name.EndsWith("CommandHandler") ||
                    service.Name.EndsWith("QueryHandler"))
                .AsImplementedInterfaces();
        }
    }
}
