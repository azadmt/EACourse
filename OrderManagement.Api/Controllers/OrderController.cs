using Microsoft.AspNetCore.Mvc;
using OrderManagement.ApplicationService;
using OrderManagement.DomainContract;

namespace OrderManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        OrderApplicationService orderApplicationService;
        public OrderController(OrderApplicationService orderApplicationService)
        {

            this.orderApplicationService = orderApplicationService;
        }

        [HttpPost]
        public IActionResult CreateOrder(CreateOrderDto createOrderDto)
        {
            orderApplicationService.CreateOrder(createOrderDto);
            return Ok();
        }

        [HttpPut]
        public IActionResult AddOrderItem(AddOrderItemDto dto)
        {
            orderApplicationService.AddOrderItem(dto);
            return Ok();
        }
    }
}