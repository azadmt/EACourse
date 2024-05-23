namespace ProductCatalog.Message
{
    public class ProductCreated
    {
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }
    }
}