using Microsoft.AspNetCore.Mvc;

namespace Order.Api.Controllers
{
    [ApiController]
    [Route("/")]
    public class DefaultController : ControllerBase
    {
        private readonly ILogger<DefaultController> _logger;

        public DefaultController(ILogger<DefaultController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "Order is running...";
        }
    }
}
