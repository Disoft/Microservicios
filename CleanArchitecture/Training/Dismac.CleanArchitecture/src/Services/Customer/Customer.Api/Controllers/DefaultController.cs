using Microsoft.AspNetCore.Mvc;

namespace Customer.Api.Controllers
{
    [ApiController]
    [Route("/")]
    public class DefaultController(
        ILogger<DefaultController> _logger) : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            _logger.LogInformation("Run!!");

            return "Running...";
        }
    }
}
