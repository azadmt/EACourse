using Framework.Core.Domain;
using OrderManagement.DomainContract;

namespace OrdeManagement.Domain
{
    public class OrderItem : Entity<Guid>
    {
        public static OrderItem CreateOrdeItem(OrderItemDto orderItemDto, Guid orderItemId)
        {
            var orderItem = new OrderItem();
            orderItem.ProductId = orderItemDto.ProductId;
            orderItem.Quantity = orderItemDto.Quantity;
            orderItem.UnitPrice = new Money(orderItemDto.UnitPrice);

            orderItem.Id = orderItemId;

            return orderItem;
        }

        public Guid ProductId { get; private set; }

        public Money UnitPrice { get; private set; }
        public uint Quantity { get; private set; }
    }
}