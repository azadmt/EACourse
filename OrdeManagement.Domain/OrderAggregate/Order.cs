using Framework.Core.Domain;
using OrderManagement.DomainContract;
using OrderManagement.DomainContract.Event;

namespace OrderManagement.Domain.OrderAggregate
{
    public class Order : AggregateRoot<Guid>
    {
        private decimal maxLimitation = 1000000000;//TODO move to Config

        public static Order CreateOrder(CreateOrderCommand createOrderDto, IGuidProvider guidProvider)
        {
            Order order = new Order();

            order.Id = guidProvider.GetGuid();
            order.CustomerId = createOrderDto.CustomerId;
            order.AddOrderItems(createOrderDto.Items);

            order.AddChanges(
                new OrderCreatedEvent(
                    order.Id,
                    order.CustomerId,
                    createOrderDto
                .Items.AsReadOnly()));
            return order;
        }

        private List<OrderItem> _orderItems = new();
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();
        public DateTime OrderDate { get; private set; }
        public Guid CustomerId { get; private set; }
        public Money Total { get; private set; }

        public void AddOrderItems(List<OrderItemDto> orderItemDtos)
        {
            foreach (var item in orderItemDtos)
            {
                if (_orderItems.Sum(x => (decimal)x.UnitPrice) + (item.UnitPrice * item.Quantity) > maxLimitation)
                {
                    throw new OrderPriceThresholdViolationException();
                }
                _orderItems.Add(OrderItem.CreateOrdeItem(item, Guid.NewGuid()));
            }
            Total = _orderItems.Sum(x => x.UnitPrice * x.Quantity);
        }
    }
}