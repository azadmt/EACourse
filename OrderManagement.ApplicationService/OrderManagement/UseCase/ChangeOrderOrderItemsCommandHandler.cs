using Framework.Core.Messeaging;
using OrdeManagement.Domain.OrderAggregate;
using OrderManagement.DomainContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.ApplicationService.OrderManagement.UseCase
{
    public class ChangeOrderOrderItemsCommandHandler : ICommandHandler<ChangeOrderOrderItemsCommand>
    {

        private IOrderRepository _orderRepository;


        public ChangeOrderOrderItemsCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;

        }

        public void Handle(ChangeOrderOrderItemsCommand command)
        {
            //validate dto
            var order = _orderRepository.Get(command.OrderId);
            order.AddOrderItems(command.OrderItemDtos);
            _orderRepository.Update(order);
        }
    }
}
