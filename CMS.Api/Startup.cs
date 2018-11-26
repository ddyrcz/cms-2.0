using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CMS.Cars;
using CMS.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CMS.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(CreateCarCommand).Assembly)
                .Where(service => service.Name.EndsWith("CommandHandler"))
                .AsImplementedInterfaces();

            builder.RegisterType(typeof(CommandBus)).AsImplementedInterfaces();

            builder.Register<Func<ICommand, ICommandHandler>>(context =>
            {
                var resolvedContext = context.Resolve<IComponentContext>();

                return command =>
                {
                    var commandType = command.GetType();

                    var commmandHandlerType = typeof(ICommandHandler<>)
                        .MakeGenericType(commandType);

                    var commandHandler = (ICommandHandler)resolvedContext
                        .Resolve(commmandHandlerType);

                    return commandHandler;
                };
            });
        }
    }
}
