using GoShop.Core.Services;
using GoShop.Domain.Interfaces;
using GoShop.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobilePhoneSoftwareController : ControllerBase
    {

        private readonly IMobilePhoneSoftwareService _mobilePhoneSoftwareService;

        public MobilePhoneSoftwareController(IMobilePhoneSoftwareService mobilePhoneSoftwareService)
        {
            _mobilePhoneSoftwareService = mobilePhoneSoftwareService;
        }

        // GET: api/MobilePhoneSoftware
        [HttpGet]
        public async Task<ActionResult<List<MobilePhoneSoftwareFiltersModel>>> GetAll([FromQuery] MobilePhoneSoftwareFiltersModel model, CancellationToken cancellationToken)
        {
            var result = await _mobilePhoneSoftwareService.GetAllAsync(model, cancellationToken);
            return Ok(result);
        }

        // GET: api/MobilePhoneHardware/Count
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetCountByFilters([FromQuery] MobilePhoneSoftwareFiltersModel model, CancellationToken cancellationToken)
        {
            var count = await _mobilePhoneSoftwareService.GetCountByFiltersAsync(model, cancellationToken);
            return Ok(count);
        }
    }
}
