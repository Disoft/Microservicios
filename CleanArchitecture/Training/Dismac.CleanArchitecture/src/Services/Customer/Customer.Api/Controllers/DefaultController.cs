using Microsoft.AspNetCore.Mvc;

namespace Customer.Api.Controllers
{
    [ApiController]
    [Route("/")]
    public class CustomerController(
        ILogger<CustomerController> _logger) : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            _logger.LogInformation("Run!!");

            return "Running...";
        }
    }
}
