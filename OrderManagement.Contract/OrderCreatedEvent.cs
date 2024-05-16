using System.Collections.ObjectModel;

namespace OrderManagement.DomainContract.Event
{
    public class OrderCreatedEvent 
    {
        public OrderCreatedEvent()
        {
                
        }
        public Guid OrderId { get;  set; }
        public decimal Total{ get;  set; }
        public Guid CustomerId { get;  set; }
        public List<OrderItemDto> OrderItems { get;  set; }
    }
}
