using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TenantPOC.Models
{
    public class TenantDbContextFactory : IDesignTimeDbContextFactory<TenantDBContext>
    {
        public TenantDBContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<TenantDBContext> optionsBuilder = new();
            _ = optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Database=TenantTesting;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True;");
            return new TenantDBContext(optionsBuilder.Options);
        }
    }
}
