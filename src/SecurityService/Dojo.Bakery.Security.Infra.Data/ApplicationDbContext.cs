using Dojo.Bakery.BuildingBlocks.Commons;
using Dojo.Bakery.Security.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;

namespace Dojo.Bakery.Security.Persistence.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,
                                        ApplicationRole,
                                        Guid,
                                        ApplicationUserClaim,
                                        ApplicationUserRole,
                                        ApplicationUserLogin,
                                        ApplicationRoleClaim,
                                        IdentityUserToken<Guid>>
    {
        private readonly ILogger<ApplicationDbContext> _logger;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ILogger<ApplicationDbContext> logger)
            : base(options)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ModelConfig(modelBuilder);
        }
        private void ModelConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Security");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            SaveAuthInfo();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override int SaveChanges()
        {
            SaveAuthInfo();
            return base.SaveChanges();
        }
        private void SaveAuthInfo()
        {
            IList<EntityEntry> modifiedEntries = ChangeTracker.Entries().Where(x => (x.State == EntityState.Added || x.State == EntityState.Modified)).ToList();
            foreach (EntityEntry entry in modifiedEntries)
            {
                if (entry.Entity is not Entity entity) continue;
                if (entry.State == EntityState.Added)
                {
                    entity.CreateEntity();
                }
                else if (entry.State == EntityState.Modified)
                {
                    entity.UpdateEntity();
                }
            }
        }
    }

}
