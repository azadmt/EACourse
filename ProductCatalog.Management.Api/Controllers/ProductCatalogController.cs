using Framework.Core.Messeaging;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Management.Api.Model;
using ProductCatalog.Message;

namespace ProductCatalog.Management.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductCatalogController : ControllerBase
    {
        private readonly ILogger<ProductCatalogController> _logger;
        private readonly IEventBus eventBus;

        public ProductCatalogController(ILogger<ProductCatalogController> logger, IEventBus eventBus)
        {
            _logger = logger;
            this.eventBus = eventBus;
        }

        [HttpGet]
        public ProductCatalogModel Get(Guid id)
        {
            return new ProductCatalogModel();
        }

        [HttpPost]
        public IActionResult Post(ProductCatalogModel model)
        {
            //TODO implement OutBox pattern
            //store in db
            eventBus.Publish(new ProductCatalogCreated() { Price = model.Price, ProductId = model.Id });
            return Ok();
        }
    }
}