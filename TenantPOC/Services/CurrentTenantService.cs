
using Microsoft.EntityFrameworkCore;
using TenantPOC.Models;

namespace TenantPOC.Services
{
    public class CurrentTenantService : ICurrentTenantService
    {
        private readonly TenantDBContext _dbContext;
        public CurrentTenantService(TenantDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string? TenantId { get; set; }
        public string? ConnectionString { get; set; }

        public async Task<bool> SetTenant(string tenantId)
        {
            var tenantInfo = await _dbContext.Tenants.FirstOrDefaultAsync(x => x.Id == tenantId);
            if (tenantInfo != null)
            {
                TenantId = tenantInfo.Id;
                ConnectionString = tenantInfo.ConnectionString;
                return true;
            }
            return false;
        }
    }
}
