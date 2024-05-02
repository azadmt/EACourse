using Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Messeaging
{
    public interface ICommandBus
    {
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
    }

    public interface IEventBus
    {
        void Publish<TEvent>(TEvent @event) where TEvent : IDomainEvent;
    }
}
