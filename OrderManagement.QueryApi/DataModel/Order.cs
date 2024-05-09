using MassTransit.Futures.Contracts;

namespace OrderManagement.QueryApi.DataModel
{
    public class Order
    {
        public Guid Id { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new();
        public DateTime OrderDate { get;  set; }
        public Guid CustomerId { get;  set; }
        public string CustomerName { get;  set; }
        public string CustomerNationalCode { get;  set; }
        public decimal Total { get;  set; }
    }

    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid OrderId{ get; set; }
        public virtual Order Order{ get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public uint Quantity { get; set; }
    }
}
