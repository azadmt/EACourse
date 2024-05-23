using Framework.Core.Messeaging;
using OrderManagement.Domain.OrderAggregate;
using OrderManagement.DomainContract;

namespace OrderManagement.ApplicationService.OrderManagement.UseCase
{
    public class ApproveOrderCommandHandler : ICommandHandler<ApproveOrderCommand>
    {
        private readonly IOrderRepository orderRepository;

        public ApproveOrderCommandHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public void Handle(ApproveOrderCommand command)
        {
            var order = orderRepository.Get(command.OrderId);
            order.Approve();
            orderRepository.Update(order);
        }
    }
}
