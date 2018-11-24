using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core
{
    public class CommandBus : ICommandBus
    {
        private readonly Func<ICommand, ICommandHandler> _handlerFactory;

        public CommandBus(Func<ICommand, ICommandHandler> handlerFactory)
        {
            _handlerFactory = handlerFactory;
        }

        public async Task Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = (ICommandHandler<TCommand>)_handlerFactory(command);
            await handler.Handle(command);
        }
    }
}
