using Framework.Core.Domain;

namespace OrderManagement.DomainContract.Event
{
    public class OrderRejectedEvent:IDomainEvent
    {
        public Guid OrderId { get; set; }

        public Guid Id { get; set; }
    }
}