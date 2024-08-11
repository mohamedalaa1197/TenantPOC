using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenantPOC.Services.TenantService;
using TenantPOC.Services.TenantService.Models;

namespace TenantPOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly ITenantService _tenantService;

        public TenantController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTenant(CreateTenantRequestModel createTenantRequestModel)
        {
            await _tenantService.CreateTenant(createTenantRequestModel);
            return Ok();
        }
    }
}
