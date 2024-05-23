namespace InventoryManagement.Api.Handler
{
    public class Stock
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public uint Quantity { get; set; }

        public void IncreaseQuantity(uint qty)
        {
            Quantity += qty;
        }
        public void DecraseQuantity(uint qty)
        {
            if (qty > Quantity)
                throw new Exception();
            Quantity -= qty;
        }
    }


}
