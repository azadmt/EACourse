using Framework.Core.Domain;
using OrderManagement.Domain.ACL;
using OrderManagement.DomainContract;
using OrderManagement.DomainContract.Event;

namespace OrderManagement.Domain.OrderAggregate
{
    public class Order : AggregateRoot<Guid>
    {
        private decimal maxLimitation = 1000000000;//TODO move to Config

        public static Order CreateOrder(CreateOrderCommand createOrderDto, Customer customer, IGuidProvider guidProvider)
        {
            if (!customer.IsActive)
            {
                throw new Exception();
            }
            Order order = new Order();

            order.Id = guidProvider.GetGuid();
            order.CustomerId = createOrderDto.CustomerId;
            order.State = OrderState.Pending;
            order.AddOrderItems(createOrderDto.Items);

            order.AddChanges(
                new OrderCreatedEvent(
                    order.Id,
                    order.CustomerId,
                    order.Total.Value,
                    createOrderDto
                .Items.AsReadOnly()));
            return order;
        }

        private List<OrderItem> _orderItems = new();
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();
        public DateTime OrderDate { get; private set; }
        public Guid CustomerId { get; private set; }
        public Money Total { get; private set; }

        public OrderState State { get; private set; }
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

        public void Approve()
        {
            if (State != OrderState.Pending)
                throw new Exception("just pending order can Approved!!!");
            State = OrderState.Approved;
            AddChanges(new OrderApprovedEvent { OrderId=Id});
        }

        public void Reject()
        {
            if (State != OrderState.Pending)
                throw new Exception("just pending order can Rejected!!!");
            State = OrderState.Rejected;
            AddChanges(new OrderRejectedEvent { OrderId = Id });
        }
    }

    public enum OrderState
    {
        Pending,
        Approved,
        Rejected,
        Delivered
    }
}