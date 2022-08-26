namespace Dojo.Bakery.Transaction.Infra.Data.Configuration;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ConfigureBase();
        builder.ConfigureAuditable();
        builder.ToTable("Brand", "Transactions");
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
    }
}
