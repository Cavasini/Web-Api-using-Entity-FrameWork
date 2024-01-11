using Look.Dtos;
using Look.Model;
using Look.Service.UsersService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Look.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersInterface _usersInterface;

        public UsersController(IUsersInterface usersInterface)
        {
            _usersInterface = usersInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IAsyncEnumerable<Users>>>> GetUsers()
        {
            return Ok(await _usersInterface.GetUsers());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Users>>>> CreateUser([FromBody] CreateUserDto userDto)
        {
            return Ok(await _usersInterface.CreateUser(userDto));
        }

        [HttpPost("CheckLogin")]
        public async Task<ActionResult<ServiceResponse<bool>>> CheckUserExistence(string userName, string password)
        {
            return Ok(await _usersInterface.CheckUserExistence(userName, password));
        }

    }
}
