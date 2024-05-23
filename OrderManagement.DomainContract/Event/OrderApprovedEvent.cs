using Framework.Core.Domain;

namespace OrderManagement.DomainContract.Event
{
    public class OrderApprovedEvent:IDomainEvent
    {
        public Guid OrderId { get; set; }

        public Guid Id {get;set;}
    }
}