using Framework.Core.Domain;
using OrdeManagement.Domain;
using OrdeManagement.Domain.OrderAggregate;
using OrderManagement.ApplicationService;
using OrderManagement.DomainContract;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace OrderManagement.Test
{
    public class OrderTest
    {

        [Fact]
        public void Create_Order()
        {
            var idProvider = new GuidProviderFake();
            var orderRepo = new OrderRepositoryFake();
            var sut = new OrderApplicationService(orderRepo, idProvider);
            var orderId = idProvider.GetGuid();
            var customerId = Guid.NewGuid();
            var orderItems = new List<OrderItemDto>();
            orderItems.Add(new OrderItemDto() { ProductId = Guid.NewGuid(), Quantity = 10, UnitPrice = 5000 });
            sut.CreateOrder(GetCreateOrder(customerId, orderItems));


            var order = orderRepo.Get(orderId);
            Assert.Equal(order.Id, orderId);
        }

        [Fact]
        public void Add_OrderItems_To_ExistingOrder()
        {
            var idProvider = new GuidProviderFake();
            var orderRepo = new OrderRepositoryFake();
            var sut = new OrderApplicationService(orderRepo, idProvider);
            var orderId = idProvider.GetGuid();
            var customerId = Guid.NewGuid();
            var orderItems = new List<OrderItemDto>();
            orderItems.Add(new OrderItemDto() { ProductId = Guid.NewGuid(), Quantity = 10, UnitPrice = 5000 });
            var existingOrder = GetCreateOrder(customerId, orderItems);
            orderRepo.Save(Order.CreateOrder(existingOrder, idProvider));

            var newOrderItems = new List<OrderItemDto>();
            var newOrderItem = new OrderItemDto { ProductId = Guid.NewGuid(), Quantity = 10, UnitPrice = 400 };
            newOrderItems.Add(newOrderItem);
            sut
                .AddOrderItem(
                new AddOrderItemDto { OrderId = orderId, OrderItemDtos = newOrderItems });

            var order = orderRepo.Get(orderId);
            Assert.True(order.OrderItems.Any(x=> x.ProductId==newOrderItem.ProductId));
            //Assert.True(order.OrderItems.Any(x=> x.ProductId==newOrderItem.ProductId));
        }

        private CreateOrderDto GetCreateOrder(Guid customerId, List<OrderItemDto> orderItemDtos)
        {
            var dto = new CreateOrderDto();
            dto.CustomerId = customerId;
            dto.Items = orderItemDtos;

            return dto;
        }
    }

    class OrderRepositoryFake : IOrderRepository
    {
        private List<Order> orders = new List<Order>();
        public Order Get(Guid id)
        {
            return orders.Single(x => x.Id == id);
        }

        public void Save(Order model)
        {
            orders.Add(model);
        }

        public void Update(Order model)
        {
            var order = orders.SingleOrDefault(x => x.Id == model.Id);
            if (orders is null)
            {
                orders.Add(model);

            }
            else
            {
                order = model;
                //rplace new value whit 
            }
        }
    }

    public class GuidProviderFake : IGuidProvider
    {

        public Guid GetGuid()
        {
            return Guid.Parse("4eddd323-b74c-41c5-84bc-42ede17bd04d");
        }
    }
}