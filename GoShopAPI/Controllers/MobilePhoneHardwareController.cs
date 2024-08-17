using GoShop.Domain.Interfaces;
using GoShop.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobilePhoneHardwareController : ControllerBase
    {
        private readonly IMobilePhoneHardwareService _mobilePhoneHardwareService;

        public MobilePhoneHardwareController(IMobilePhoneHardwareService mobilePhoneHardwareService)
        {
            _mobilePhoneHardwareService = mobilePhoneHardwareService;
        }

        // GET: api/MobilePhoneHardware
        [HttpGet]
        public async Task<ActionResult<List<MobilePhoneHardwareFiltersModel>>> GetAll([FromQuery] MobilePhoneHardwareFiltersModel model, CancellationToken cancellationToken)
        {
            var result = await _mobilePhoneHardwareService.GetAllAsync(model, cancellationToken);
            return Ok(result);
        }

        // GET: api/MobilePhoneHardware/Count
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetCountByFilters([FromQuery] MobilePhoneHardwareFiltersModel model, CancellationToken cancellationToken)
        {
            var count = await _mobilePhoneHardwareService.GetCountByFiltersAsync(model, cancellationToken);
            return Ok(count);
        }
    }
}
