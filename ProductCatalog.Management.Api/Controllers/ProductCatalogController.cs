using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Management.Api.Model;

namespace ProductCatalog.Management.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductCatalogController : ControllerBase
    {
        private readonly ILogger<ProductCatalogController> _logger;

        public ProductCatalogController(ILogger<ProductCatalogController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ProductCatalogModel Get(Guid id)
        {
            return new ProductCatalogModel();
        }

        [HttpPost]
        public ProductCatalogModel Post(ProductCatalogModel model)
        {
            return new ProductCatalogModel();
        }
    }
}