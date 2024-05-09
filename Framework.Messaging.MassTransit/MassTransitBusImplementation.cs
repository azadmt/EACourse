using Framework.Core.Domain;
using Framework.Core.Messeaging;
using MassTransit;

namespace Framework.Messaging.MassTransit
{
    public class MassTransitBusImplementation : IEventBus
    {
        private readonly IBusControl _bus;

        public MassTransitBusImplementation(IBusControl bus)
        {
            _bus = bus;
        }

        public void Publish<TEvent>(TEvent @event) where TEvent : IDomainEvent
        {
            _bus.Publish(@event).GetAwaiter().GetResult();
        }
    }
}