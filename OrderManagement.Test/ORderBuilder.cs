using Framework.Core.Domain;
using OrderManagement.Domain.OrderAggregate;
using OrderManagement.DomainContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Test
{
    public class OrderBuilder
    {
        private Guid _orderId;
        private Guid _customerId;
        private IGuidProvider _guidProvider;
        private List<OrderItemDto> _orderItems = new();

        public OrderBuilder(IGuidProvider guidProvider)
        {
            _guidProvider = guidProvider;
            _orderId = _guidProvider.GetGuid();
        }

        public OrderBuilder WithCustomerId(Guid id)
        {
            _customerId = id;
            return this;
        }

        public OrderBuilder WithOrderItem(OrderItemDto dto)
        {
            _orderItems.Add(dto);
            return this;
        }

        public Order Build()
        {
            return Order.CreateOrder(new CreateOrderCommand { CustomerId = _customerId, Items = _orderItems },new Domain.ACL.Customer(), _guidProvider);
        }
    }
}