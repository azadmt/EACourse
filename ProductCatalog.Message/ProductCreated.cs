namespace ProductCatalog.Message
{
    public class ProductCatalogCreated
    {
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }
    }
}