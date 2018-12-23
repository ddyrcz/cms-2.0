using Autofac;
using CMS.Core.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommandBus>().AsImplementedInterfaces();

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

            builder.Register<Func<IQuery, IQueryHandler>>(context =>
            {
                var resolvedContext = context.Resolve<IComponentContext>();

                return query =>
                {
                    var queryType = query.GetType();

                    var queryHandlerType = typeof(IQueryHandler<>)
                        .MakeGenericType(queryType);

                    var commandHandler = (IQueryHandler)resolvedContext
                        .Resolve(queryHandlerType);

                    return commandHandler;
                };
            });
        }
    }
}
