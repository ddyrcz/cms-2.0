using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
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
