using InventortyManagement.MessageContract;
using MassTransit;
using OrderManagement.DomainContract.Event;

namespace InventoryManagement.Api.Handler
{
    public class OrderCreatedHandler : IConsumer<OrderCreatedEvent>
    {
        public Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            //TODO : use decorator or interceptor pattern for all consumers
            if (DB.CheckMessageIdExist(context.Message.Id))
                return Task.CompletedTask;

            var orderItems = context.Message.OrderItems;
            try
            {
                foreach (var item in orderItems)
                {

                    var stock = DB.Get(item.ProductId);
                    stock.DecraseQuantity(item.Quantity);
                }
            }
            catch (Exception ex)
            {
                context.Publish(new AdjustmentProceedFaildEvent() { OrderId = context.Message.OrderId });

            //    throw;
            }
            context.Publish(new AdjustmentProceedSuccessEvent() { OrderId=context.Message.OrderId});
            return Task.CompletedTask;  
        }
    }

    public static class DB
    {
        static List<Stock> stocks = new();
        static List<Guid> inbox= new();

        static DB()
        {
            stocks.Add(new Stock()
            {
                Id = new Guid("5B02A3A2-4CDD-4076-8DDE-BDCAE904CD01"),
             
                ProductId = new Guid("5B02A3A2-4CDD-4076-8DDE-BDCAE904CD03"),
                Quantity = 100,
            });
        }

        public static Stock Get(Guid productId)
        {
            return stocks.FirstOrDefault(x => x.ProductId == productId);
        }

        public static bool CheckMessageIdExist(Guid messageId)
        {
            return inbox.Any(x => x== messageId);
        }
    }
}
