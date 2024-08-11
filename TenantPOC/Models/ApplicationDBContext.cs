using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TenantPOC.Services;

namespace TenantPOC.Models
{
    public class ApplicationDBContext : DbContext
    {
        private readonly ICurrentTenantService _currentTenantService;

        public string CurrentTenantId;

        public string CurrentTenantConnectionString { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options, ICurrentTenantService currentTenantService) : base(options)
        {
            _currentTenantService = currentTenantService;
            CurrentTenantId = _currentTenantService.TenantId;
            CurrentTenantConnectionString = _currentTenantService.ConnectionString;
        }
        public DbSet<Product> Products { get; set; }


        // override the savechanges

        public override int SaveChanges()
        {

            foreach (var entry in ChangeTracker.Entries<IMustHaveTenant>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                    case EntityState.Modified:
                        entry.Entity.TenantId = CurrentTenantId;
                        break;
                }
            }

            return base.SaveChanges();
        }

        //override the onModelCreatng (Getting)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IMustHaveTenant>().HasQueryFilter(a => a.TenantId == CurrentTenantId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var tenantConnectionString = CurrentTenantConnectionString;
            if (!string.IsNullOrEmpty(tenantConnectionString))
            {
                _ = optionsBuilder.UseSqlServer(tenantConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
