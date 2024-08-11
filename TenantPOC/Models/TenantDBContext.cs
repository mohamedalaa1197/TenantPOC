using Microsoft.EntityFrameworkCore;

namespace TenantPOC.Models
{
    public class TenantDBContext : DbContext
    {
        public TenantDBContext(DbContextOptions<TenantDBContext> options) : base(options) { }

        public DbSet<Tenant> Tenants { get; set; }
    }
}
