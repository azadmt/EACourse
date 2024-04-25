using Framework.Core.Messeaging;

namespace OrderManagement.DomainContract
{
    public class CreateOrderCommand:ICommand
    {
        public Guid CustomerId { get; set; }

        public List<OrderItemDto> Items { get; set; }

        public bool Validate()
        {
            return true;
        }
    }
}
