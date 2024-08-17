using GoShop.Domain.Entities;
using GoShop.Domain.Interfaces;
using GoShop.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<List<MobilePhoneFiltersModel>>> GetAll([FromQuery] UserFiltersModel model, CancellationToken cancellationToken)
        {
            var result = await _userService.GetAllAsync(model, cancellationToken);
            return Ok(result);
        }

        // GET: api/User/Count
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetCountByFilters([FromQuery] UserFiltersModel model, CancellationToken cancellationToken)
        {
            var count = await _userService.GetCountByFiltersAsync(model, cancellationToken);
            return Ok(count);
        }

        [HttpPost]
        public async Task<ActionResult<UserEntity>> CreateUser([FromQuery] UserEntity entity, CancellationToken cancellationToken)
        {
            var result = await _userService.CreateUserAsync(entity, cancellationToken);

            return Ok(result);
        }
    }
}
