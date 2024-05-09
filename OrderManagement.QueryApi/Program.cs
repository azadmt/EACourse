using MassTransit;
using Microsoft.EntityFrameworkCore;
using OrderManagement.QueryApi.EventHandler;

namespace OrderManagement.QueryApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.builder.Services
            builder.Services
                .AddDbContext<OrderManagementQueryDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("default")));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddMassTransit(x =>
            {
                x.AddConsumer<OrderCreatedEventHnadler>();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ConfigureJsonSerializerOptions(options =>
                    {
                        // customize the JsonSerializerOptions here
                        return options;
                    });
                    cfg.ConfigureEndpoints(context);
                    //cfg.UseConsumeFilter(typeof(MyConsumeLogFilter<>), context);

                    //cfg.ReceiveEndpoint(nameof(ProductCategoryCreatedEvent), e =>
                    //{
                    //    e.ConfigureConsumer<ProductCategoryCreatedEventHandler>(context);
                    //});
                    cfg.Host("localhost", "ea1403", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                });
            });
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
