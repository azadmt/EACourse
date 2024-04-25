using Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.DomainContract.Event
{
    public class OrderCreatedEvent : IDomainEvent
    {
        public OrderCreatedEvent(Guid orderId, Guid customerId, ReadOnlyCollection<OrderItemDto> orderItems)
        {
            OrderId = orderId;
            CustomerId = customerId;
            OrderItems = orderItems;
        }
        public Guid OrderId { get; private set; }
        public Guid CustomerId{ get; private set; }
        public ReadOnlyCollection<OrderItemDto> OrderItems{ get; private set; }
    }
}
