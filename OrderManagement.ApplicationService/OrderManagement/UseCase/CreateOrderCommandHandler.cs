using Framework.Core.Domain;
using Framework.Core.Messeaging;
using OrderManagement.ApplicationService.ACL;
using OrderManagement.Domain.OrderAggregate;
using OrderManagement.DomainContract;

namespace OrderManagement.ApplicationService.OrderManagement.UseCase
{
    public class CreateOrderCommandHandler :
        ICommandHandler<CreateOrderCommand>

    {
        private IOrderRepository _orderRepository;
        private readonly IGuidProvider guidProvider;
        private IEventBus eventBus;
        private readonly ICustomerDataProvider customerDataProvider;

        public CreateOrderCommandHandler(IOrderRepository orderRepository,
            IGuidProvider guidProvider,
            IEventBus eventBus,
            ICustomerDataProvider customerDataProvider)
        {
            _orderRepository = orderRepository;
            this.guidProvider = guidProvider;
            this.eventBus = eventBus;
            this.customerDataProvider = customerDataProvider;
        }

        public void Handle(CreateOrderCommand command)
        {
            var customer = customerDataProvider.GetCustomer(command.CustomerId);
            //validate dto
            var order = Order.CreateOrder(command, customer, guidProvider);

            _orderRepository.Save(order);
            //var changes = order.GetChanges();
            //foreach (var @event in changes)
            //{
            //    eventBus.Publish(@event);//OutBox Pattern
            //}
        }
    }
}