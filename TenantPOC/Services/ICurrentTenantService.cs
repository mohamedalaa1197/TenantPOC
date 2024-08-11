namespace TenantPOC.Services
{
    public interface ICurrentTenantService
    {
        string? TenantId { get; set; }
        public Task<bool> SetTenant(string tenantId);
        string? ConnectionString { get; set; }

    }
}
