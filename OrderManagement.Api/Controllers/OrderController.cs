using Framework.Core.Messeaging;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.ApplicationService;
using OrderManagement.DomainContract;
using System.Net.Http;

namespace OrderManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        // OrderApplicationService orderApplicationService;
        private ICommandBus commandBus;

        private readonly IHttpClientFactory _httpClientFactory;

        public OrderController(ICommandBus commandBus, IHttpClientFactory httpClientFactory)
        {
            //this.orderApplicationService = orderApplicationService;
            this.commandBus = commandBus;
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public IActionResult CreateOrder(CreateOrderCommand command)
        {
            commandBus.Send(command);
            return Ok();
        }

        [HttpPut]
        public IActionResult AddOrderItem(ChangeOrderOrderItemsCommand dto)
        {
            commandBus.Send(dto);
            return Ok();
        }
    }
}