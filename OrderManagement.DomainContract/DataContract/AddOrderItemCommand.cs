using Framework.Core.Messeaging;

namespace OrderManagement.DomainContract
{
    public class ChangeOrderOrderItemsCommand : ICommand
    {
        public Guid OrderId { get; set; }
        public List<OrderItemDto> OrderItemDtos { get; set; }

        public bool Validate()
        {
            return true;
        }
    }
}
