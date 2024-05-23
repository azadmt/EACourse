using Framework.Core.Domain;
using Framework.Core.Messeaging;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.OrderAggregate;
using OrderManagement.ApplicationService.OrderManagement.UseCase;
using OrderManagement.DomainContract;
using OrderManagement.Persistence.Ef;
using MassTransit;
using Framework.Messaging.MassTransit;
using OrderManagement.CustomerManagement.ACL;
using OrderManagement.ApplicationService.ACL;
using OrderManagement.Api.MessageHandler;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
 .AddDbContext<OrderManagementDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("default")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICommandHandler<ChangeOrderOrderItemsCommand>, ChangeOrderOrderItemsCommandHandler>();
builder.Services.AddScoped<ICommandHandler<CreateOrderCommand>, CreateOrderCommandHandler>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IGuidProvider, DefaultGuidProvider>();
builder.Services.AddScoped<ICommandBus, CommandBus>();
builder.Services.AddScoped<IEventBus, MassTransitBusImplementation>();
builder.Services.AddScoped<ICustomerDataProvider, CustomerDataProvider>();


builder.Services.AddHttpClient();
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<ProductCatalogCreatedHandler>();
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