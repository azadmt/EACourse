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
            orderItem.UnitPrice = orderItemDto.UnitPrice;
            //orderItem.Id = guidProvider.GetGuid();
            orderItem.Id = orderItemId;

            return orderItem;
        }
        public Guid ProductId { get; private set; }
        public decimal UnitPrice { get; private set; }
        public uint Quantity { get; private set; }
    }
}