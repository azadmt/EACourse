using Framework.Core.Domain;
using OrderManagement.DomainContract;
using OrderManagement.DomainContract.Event;

namespace OrdeManagement.Domain
{
    public class Order : AggregateRoot<Guid>
    {
        private decimal maxLimitation=1000000;

        public static Order CreateOrder(CreateOrderCommand createOrderDto, IGuidProvider guidProvider)
        {

            Order order = new Order();

            order.Id = guidProvider.GetGuid();
            order.CustomerId = createOrderDto.CustomerId;
            order.OrderItems = createOrderDto
                .Items
                .Select(x => OrderItem.CreateOrdeItem(x, Guid.NewGuid()))
                .ToList();

            order.AddChanges(
                new OrderCreatedEvent(
                    order.Id,
                    order.CustomerId, 
                    createOrderDto
                .Items.AsReadOnly()));
            return order;
        }
        public List<OrderItem> OrderItems { get; private set; }
        public DateTime OrderDate { get; private set; }
        public Guid CustomerId { get; private set; }
        public Money Total{ get; private set; }

        public void AddOrderItems(List<OrderItemDto> orderItemDtos)
        {
            foreach (var item in orderItemDtos)
            {
                if (orderItemDtos.Sum(x => x.UnitPrice) + (item.UnitPrice * item.Quantity) > maxLimitation)
                {
                    throw new Exception();
                }
                    OrderItems.Add(OrderItem.CreateOrdeItem(item, Guid.NewGuid()));
            }
        }
    }
}