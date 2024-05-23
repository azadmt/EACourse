using Framework.Core.Messeaging;
using OrderManagement.Domain.OrderAggregate;
using OrderManagement.DomainContract;

namespace OrderManagement.ApplicationService.OrderManagement.UseCase
{
    public class RejectOrderCommandHandler : ICommandHandler<RejectOrderCommand>
    {
        private readonly IOrderRepository orderRepository;

        public RejectOrderCommandHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public void Handle(RejectOrderCommand command)
        {
            var order = orderRepository.Get(command.OrderId);
            order.Reject();
            orderRepository.Update(order);

        }
    }
}
