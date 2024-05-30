using Framework.Core.Messeaging;
using InventortyManagement.MessageContract;
using MassTransit;
using OrderManagement.DomainContract;

namespace OrderManagement.Api.MessageHandler
{
    public class AdjustmentProceedFaildEventHandler : IConsumer<AdjustmentProceedFaildEvent>
    {
        private readonly ICommandBus commandBus;

        public AdjustmentProceedFaildEventHandler(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
        }
        public async Task Consume(ConsumeContext<AdjustmentProceedFaildEvent> context)
        {
            commandBus.Send(new RejectOrderCommand { OrderId=context.Message.OrderId});
        }
    }
}
