using Framework.Core.Domain;
using Framework.Core.Messeaging;
using OrdeManagement.Domain.OrderAggregate;
using OrderManagement.DomainContract;

namespace OrderManagement.ApplicationService.OrderManagement.UseCase
{
    public class CreateOrderCommandHandler :
        ICommandHandler<CreateOrderCommand>

    {
        private IOrderRepository _orderRepository;
        private readonly IGuidProvider guidProvider;
        private IEventBus eventBus;
        public CreateOrderCommandHandler(IOrderRepository orderRepository, IGuidProvider guidProvider)
        {
            _orderRepository = orderRepository;
            this.guidProvider = guidProvider;
        }

        public void Handle(CreateOrderCommand command)
        {
            //validate dto
            var order = OrdeManagement.Domain.Order.CreateOrder(command, guidProvider);

            _orderRepository.Save(order);
            var changes = order.GetChanges();
            foreach (var @event in changes)
            {
                eventBus.Publish(@event);//OutBox Pattern
            }

        }
    }

}
