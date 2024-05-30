using Framework.Core.Messeaging;
using InventortyManagement.MessageContract;
using MassTransit;
using OrderManagement.DomainContract;

namespace OrderManagement.Api.MessageHandler
{
    public class AdjustmentProceedSuccessEventEvetHandler : IConsumer<AdjustmentProceedSuccessEvent>
    {
        private readonly ICommandBus commandBus;

        public AdjustmentProceedSuccessEventEvetHandler(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
        }
        public async Task Consume(ConsumeContext<AdjustmentProceedSuccessEvent> context)
        {
            commandBus.Send(new ApproveOrderCommand { OrderId = context.Message.OrderId });
        }
    }
}
