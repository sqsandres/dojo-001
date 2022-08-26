


namespace Dojo.Bakery.Transaction.Infra.Data;

public class ApplicationDbContext : DbContext
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
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        //modelBuilder.ApplyConfiguration(new ProductConfiguration());
        //modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        //modelBuilder.ApplyConfiguration(new ClientConfiguration());
        //modelBuilder.ApplyConfiguration(new BrandConfiguration());

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
