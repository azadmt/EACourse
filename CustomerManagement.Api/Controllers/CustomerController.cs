using CustomerManagement.Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
             
        }

        [HttpGet("{id:guid}")]
        public CustomerModel Get(Guid id)
        {
         
            return DB.GetCustomer(id);            
        }
    }
}