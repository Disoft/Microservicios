using Identity.Service.Queries;
using Identity.Service.Queries.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Shared.Utils;
using System.Security.Claims;

namespace Identity.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("v1/users")]
    public class UserController(ILogger<UserController> _logger, IUserQueryService _userQueryServices): ControllerBase
    {
        [HttpGet]
        public async Task<DataCollection<UserDto>> GetAll(int page = 1, int take = 10, string ids = null)
        { 
            IEnumerable<string> users = ids?.Split(',');

            var userId = User.Claims.Single(x => x.Type.Equals(ClaimTypes.NameIdentifier)).Value;

            return await _userQueryServices.GetAllAsync(page, take, users);
        }


        [HttpGet("{id}")]
        public async Task<UserDto> Get(string id)
        {
            return await _userQueryServices.GetAsync(id);
        }
    }
}
