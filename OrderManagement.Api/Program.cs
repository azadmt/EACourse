using Framework.Core.Domain;
using Framework.Core.Messeaging;
using Microsoft.EntityFrameworkCore;
using OrdeManagement.Domain.OrderAggregate;
using OrderManagement.ApplicationService.OrderManagement.UseCase;
using OrderManagement.DomainContract;
using OrderManagement.Persistence.Ef;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
 .AddDbContext<OrderManagementDbContext>(opt => opt.UseInMemoryDatabase("OrderManagementDbContext"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICommandHandler<ChangeOrderOrderItemsCommand>, ChangeOrderOrderItemsCommandHandler>();
builder.Services.AddScoped<ICommandHandler<CreateOrderCommand>, CreateOrderCommandHandler>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IGuidProvider, DefaultGuidProvider>();
builder.Services.AddScoped<ICommandBus, CommandBus>();
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