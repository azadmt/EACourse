using Framework.Core.Messeaging;
using Framework.OutboxEventPublisher;
using MassTransit;
using System.Data.SqlClient;
using System.Data;
using Framework.Messaging.MassTransit;

namespace OrderManagement.OutboxPublisher
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                     .ConfigureServices((hostContext, services) =>
                     {
                         services.AddSingleton<IDbConnection>(new SqlConnection(hostContext.Configuration.GetConnectionString("default")));
                         services.AddSingleton<IEventBus, MassTransitBusImplementation>();
                         services.AddSingleton<OutboxManager>();

                         services.AddMassTransit(x =>
                         {
                             x.UsingRabbitMq((context, cfg) =>
                             {
                                 cfg.Host("localhost", "ea1403", h =>
                                 {
                                     h.Username("guest");
                                     h.Password("guest");
                                 });
                             });
                         });
                         services.AddHostedService<Worker>();
                     })
                    .Build();

            host.Run();
        }
    }
}