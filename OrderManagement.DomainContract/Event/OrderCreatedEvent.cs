using Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
            OrderItems = orderItems.ToList();
        }
        //[JsonInclude]
        public Guid OrderId { get;  set; }
        //[JsonInclude]
        public Guid CustomerId { get;  set; }
        //[JsonInclude]
        public decimal Total { get; }
     //   [JsonInclude]
        public List<OrderItemDto> OrderItems { get;  set; }

       // [JsonInclude]
        public Guid Id { get;  set; }
    }
}