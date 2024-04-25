using Framework.Core.Messeaging;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.ApplicationService;
using OrderManagement.DomainContract;

namespace OrderManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        // OrderApplicationService orderApplicationService;
        ICommandBus commandBus;
        public OrderController(ICommandBus commandBus)
        {

            //this.orderApplicationService = orderApplicationService;
            this.commandBus = commandBus;
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