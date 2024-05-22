using MassTransit;
using OrderManagement.DomainContract.Event;
using OrderManagement.QueryApi.DataModel;

namespace OrderManagement.QueryApi.EventHandler
{
    public class OrderCreatedEventHnadler : IConsumer<OrderCreatedEvent>
    {
        private readonly OrderManagementQueryDbContext dbContext;

        public OrderCreatedEventHnadler(OrderManagementQueryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            //context.Message.CustomerId
            var order = GetOrder(context.Message);
            // get customer info
            // get product info
            dbContext.Orders.Add(order);

            //dbContext.OrderItem.AddRange(order.OrderItems);
            await dbContext.SaveChangesAsync();
            Console.WriteLine($"Consume {context.Message.OrderId} at  {DateTime.Now}");
        }

        private Order GetOrder(OrderCreatedEvent orderCreatedEvent)
        {
            var order = new Order();

            order.Id = orderCreatedEvent.OrderId;
            order.CustomerId = orderCreatedEvent.CustomerId; ;
            order.CustomerName = "my customername";
            order.CustomerNationalCode = "1111111";
            order.Total = orderCreatedEvent.Total;
            foreach (var item in orderCreatedEvent.OrderItems)
            {
                order.OrderItems.Add(new OrderItem
                {
                    Id = item.Id,
                    OrderId = order.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    ProductName = " p name",
                });
            }
            return order;
        }
    }
}