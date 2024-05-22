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
        public OrderCreatedEvent()
        {
        }

        public OrderCreatedEvent(Guid orderId, Guid customerId, decimal total, ReadOnlyCollection<OrderItemDto> orderItems)
        {
            Id = Guid.NewGuid();
            OrderId = orderId;
            CustomerId = customerId;
            Total = total;
            OrderItems = orderItems;
        }

        public Guid OrderId { get; private set; }
        public Guid CustomerId { get; private set; }
        public decimal Total { get; }
        public ReadOnlyCollection<OrderItemDto> OrderItems { get; private set; }
        public Guid Id { get; private set; }
    }
}