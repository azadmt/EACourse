using Framework.Core.Messeaging;
using InventortyManagement.MessageContract;
using MassTransit;
using OrderManagement.DomainContract;

namespace OrderManagement.Api.MessageHandler
{
    public class OrderQuantityProceedFaildEventHandler : IConsumer<OrderQuantityProceedFaildEvent>
    {
        private readonly ICommandBus commandBus;

        public OrderQuantityProceedFaildEventHandler(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
        }
        public async Task Consume(ConsumeContext<OrderQuantityProceedFaildEvent> context)
        {
            commandBus.Send(new RejectOrderCommand { OrderId=context.Message.OrderId});
        }
    }
}
