using TenantPOC.Services.TenantService.Models;

namespace TenantPOC.Services.TenantService
{
    public interface ITenantService
    {
       Task CreateTenant(CreateTenantRequestModel requestModel);
    }
}
