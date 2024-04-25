namespace OrderManagement.DomainContract
{
    public class OrderItemDto
    {
        public Guid ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public uint Quantity { get; set; }
    }
}
