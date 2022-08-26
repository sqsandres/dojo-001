namespace Dojo.Bakery.Transaction.Infra.Data.Configuration;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ConfigureBase();
        builder.ConfigureAuditable();
        builder.ToTable("Product", "Transactions");
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);            
        builder.Property(x => x.UnitPrice).IsRequired().HasDefaultValue(0).HasPrecision(10, 2);
        builder.Property(x => x.UnitId).IsRequired();
        builder.Property(x => x.CategoryId).IsRequired();
        builder.Property(x => x.BrandId).IsRequired();
        builder.Property(x => x.QR).IsRequired().HasMaxLength(255);
    }
}
