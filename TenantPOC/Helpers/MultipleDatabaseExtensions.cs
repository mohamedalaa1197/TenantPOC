using Microsoft.EntityFrameworkCore;
using TenantPOC.Models;

namespace TenantPOC.Helpers
{
    public static class MultipleDatabaseExtensions
    {
        public static IServiceCollection AddAndMigrateTenantDatabases(this IServiceCollection services, IConfiguration configuration)
        {
            //apply migrations on TenantDBContext (Cebtral DB)
            using IServiceScope scopeTenant = services.BuildServiceProvider().CreateScope();
            var tenantDb = scopeTenant.ServiceProvider.GetRequiredService<TenantDBContext>();

            if (tenantDb.Database.GetPendingMigrations().Any())
            {
                tenantDb.Database.Migrate();
            }

            //get list of all the tenant
            var tenantsInDB = tenantDb.Tenants.ToList();
            var defaultConnectionString = configuration.GetConnectionString("DefaultConnection");

            foreach (var tenant in tenantsInDB)
            {
                var connectionString = string.IsNullOrEmpty(tenant.ConnectionString) ? defaultConnectionString : tenant.ConnectionString;

                using var scopeApplication = services.BuildServiceProvider().CreateScope();
                var dbContext = scopeApplication.ServiceProvider.GetRequiredService<ApplicationDBContext>();
                dbContext.Database.SetConnectionString(connectionString);
                if (dbContext.Database.GetPendingMigrations().Any())
                {
                    dbContext.Database.Migrate();
                }
            }


            return services;
        }
    }
}

