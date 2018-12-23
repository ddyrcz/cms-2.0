﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core
{
    public interface ICommandBus
    {
        Task Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
