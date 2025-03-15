using Api.Gateway.Models;
using Api.Gateway.Models.Customer.DTOs;
using Api.Gateway.Proxies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Gateway.WebClient.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("clients")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly ICustomerProxy _customerProxy;

        public ClientController(ILogger<ClientController> logger, ICustomerProxy customerProxy)
        {
            _logger = logger;
            _customerProxy = customerProxy;
        }

        [HttpGet("{id}")]
        public async Task<ClientDto> Get([FromQuery] int id)
        {
            return await _customerProxy.GetAsync(id);
        }

        [HttpGet]
        public async Task<DataCollection<ClientDto>> GetAll([FromQuery] int page = 1, int take = 10)
        {
            return await _customerProxy.GetAllAsync(page, take);
        }
    }
}
