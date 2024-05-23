using Framework.Core.Messeaging;
using InventortyManagement.MessageContract;
using MassTransit;
using OrderManagement.DomainContract;

namespace OrderManagement.Api.MessageHandler
{
    public class OrderQuantityProceedSuccessEvetHandler : IConsumer<OrderQuantityProceedSuccessEvent>
    {
        private readonly ICommandBus commandBus;

        public OrderQuantityProceedSuccessEvetHandler(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
        }
        public async Task Consume(ConsumeContext<OrderQuantityProceedSuccessEvent> context)
        {
            commandBus.Send(new ApproveOrderCommand { OrderId = context.Message.OrderId });
        }
    }
}
