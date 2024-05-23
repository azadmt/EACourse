using InventoryManagement.Api.Handler;
using MassTransit;
using OrderManagement.DomainContract.Event;

namespace InventoryManagement.Service.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddMassTransit(x =>
            {
                x.AddConsumer<OrderCreatedHandler>();
                x.UsingRabbitMq((context, cfg) =>
                {
      
                    cfg.ConfigureEndpoints(context);
              
                    cfg.Host("localhost", "ea1403", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                });
            });
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
