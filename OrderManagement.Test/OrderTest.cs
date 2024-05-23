using OrderManagement.Domain;
using OrderManagement.ApplicationService;
using OrderManagement.ApplicationService.OrderManagement.UseCase;
using OrderManagement.DomainContract;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using OrderManagement.Domain.OrderAggregate;

namespace OrderManagement.Test
{
    public class OrderTest
    {
        [Fact]
        public void Create_Order()
        {
            var orderRepo = new OrderRepositoryFake();
            var orderId = Guid.NewGuid();
            var sut = new CreateOrderCommandHandler(orderRepo, new GuidProviderFake(orderId), null,new CustomerDataProviderFake());
            var customerId = Guid.NewGuid();
            var orderItems = new List<OrderItemDto>();
            orderItems.Add(new OrderItemDto() { ProductId = Guid.NewGuid(), Quantity = 10, UnitPrice = 5000 });
            sut.Handle(GetCreateOrderCommand(customerId, orderItems));

            var order = orderRepo.Get(orderId);
            Assert.Equal(order.Id, orderId);
        }

        [Fact]
        public void Add_OrderItems_To_ExistingOrder()
        {
            var orderRepo = new OrderRepositoryFake();
            var sut = new ChangeOrderOrderItemsCommandHandler(orderRepo);
            var orderId = Guid.NewGuid();
            var customerId = Guid.NewGuid();
            var orderItems = new List<OrderItemDto>
            {
                new OrderItemDto() { ProductId = Guid.NewGuid(), Quantity = 10, UnitPrice = 5000 }
            };
            var existingOrder = GetCreateOrderCommand(customerId, orderItems);
            orderRepo.Save(Order.CreateOrder(existingOrder,new Domain.ACL.Customer(), new GuidProviderFake(orderId)));

            var newOrderItems = new List<OrderItemDto>();
            var newOrderItem = new OrderItemDto { ProductId = Guid.NewGuid(), Quantity = 10, UnitPrice = 400 };
            newOrderItems.Add(newOrderItem);
            sut.Handle(
                new ChangeOrderOrderItemsCommand { OrderId = orderId, OrderItemDtos = newOrderItems });

            var order = orderRepo.Get(orderId);
            Assert.True(order.OrderItems.Any(x => x.ProductId == newOrderItem.ProductId));
            //Assert.True(order.OrderItems.Any(x=> x.ProductId==newOrderItem.ProductId));
        }

        private static CreateOrderCommand GetCreateOrderCommand(Guid customerId, List<OrderItemDto> orderItemDtos)
        {
            var dto = new CreateOrderCommand();
            dto.CustomerId = customerId;
            dto.Items = orderItemDtos;

            return dto;
        }
    }
}