using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.DomainContract
{
    public class CreateOrderDto
    {
        public Guid CustomerId { get; set; }

        public List<OrderItemDto> Items { get; set; }
    }

    public class AddOrderItemDto
    {
        public Guid OrderId { get; set; }
        public List<OrderItemDto> OrderItemDtos { get; set; }
    }

    public class OrderItemDto
    {
        public Guid ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public uint Quantity { get; set; }
    }
}
