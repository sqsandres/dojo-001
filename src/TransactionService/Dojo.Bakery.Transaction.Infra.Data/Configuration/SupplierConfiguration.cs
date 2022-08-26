
namespace Dojo.Bakery.Transaction.Infra.Data.Configuration;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ConfigureBase();
        builder.ConfigureAuditable();
        builder.ToTable("Supplier", "Transactions");
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.DocumentId).IsRequired().HasMaxLength(50);
        builder.Property(x => x.DocumentTypeId).IsRequired();
        builder.Property(x => x.Address).IsRequired().HasMaxLength(50);
        builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
    }
}
