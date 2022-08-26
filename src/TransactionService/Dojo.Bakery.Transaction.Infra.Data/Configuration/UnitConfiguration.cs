namespace Dojo.Bakery.Transaction.Infra.Data.Configuration;

public class UnitConfiguration : IEntityTypeConfiguration<Unit>
{
    public void Configure(EntityTypeBuilder<Unit> builder)
    {
        builder.ConfigureBase();
        builder.ConfigureAuditable();
        builder.ToTable("Unit", "Transactions");
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

        builder.HasData(new[] {
                new { Name = "Pounds", 
                    Id = new Guid("a4d42316-b54d-4ad0-9006-667fa6e5fd6f"), 
                    CreatedOn = DateTime.Now,
                    IsActive = true},
                new { Name = "Kgs", 
                    Id = new Guid("11be23ad-a119-4329-ab8c-daf91aa7d9e5"), 
                    CreatedOn = DateTime.Now,
                    IsActive = true},
                new { Name = "Tons", 
                    Id = new Guid("1cd6c37b-065b-41b8-b088-cd50bc6893a9"), 
                    CreatedOn = DateTime.Now,
                    IsActive = true}
            });        
    }
}
