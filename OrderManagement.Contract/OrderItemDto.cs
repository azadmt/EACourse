namespace OrderManagement.DomainContract
{
    public class OrderItemDto
    {
        public OrderItemDto()
        {
                
        }
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public uint Quantity { get; set; }
    }
}
