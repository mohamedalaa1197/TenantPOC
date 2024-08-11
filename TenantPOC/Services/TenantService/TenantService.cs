using Microsoft.EntityFrameworkCore;
using TenantPOC.Models;
using TenantPOC.Services.TenantService.Models;

namespace TenantPOC.Services.TenantService
{
    public class TenantService : ITenantService
    {
        private readonly TenantDBContext _context;
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;
        public TenantService(TenantDBContext context, IConfiguration configuration, IServiceProvider serviceProvider)
        {
            _context = context;
            _configuration = configuration;
            _serviceProvider = serviceProvider;
        }

        public async Task CreateTenant(CreateTenantRequestModel requestModel)
        {
            string newConnectionString = "";
            if (requestModel.IsIsolaed)
            {
                //generating a new connectionString
                var dbName = "tenantAppDb-" + requestModel.Id;

                var defaultConnectionString = _configuration.GetConnectionString("DefaultConnection");
                newConnectionString = defaultConnectionString.Replace("TenantTesting", dbName);
                //create a new tenant and apply any pending migrations
                try
                {
                    using var scopeTenant = _serviceProvider.CreateScope();
                    var dbContext = scopeTenant.ServiceProvider.GetRequiredService<ApplicationDBContext>();
                    dbContext.Database.SetConnectionString(newConnectionString);
                    if (dbContext.Database.GetPendingMigrations().Any())
                    {
                        dbContext.Database.Migrate();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            var tenant = new Tenant()
            {
                Id = requestModel.Id,
                Name = requestModel.Name,
                ConnectionString = newConnectionString,
                SubscribtionLevel = "trial"
            };

            _context.Add(tenant);
            await _context.SaveChangesAsync();


        }
    }
}
