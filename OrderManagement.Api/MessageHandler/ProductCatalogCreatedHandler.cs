using MassTransit;
using ProductCatalog.Message;

namespace OrderManagement.Api.MessageHandler
{
    public class ProductCatalogCreatedHandler : IConsumer<ProductCatalogCreated>
    {
        public Task Consume(ConsumeContext<ProductCatalogCreated> context)
        {
            //Store in Db Or cache
            return Task.CompletedTask;
        }
    }
}
