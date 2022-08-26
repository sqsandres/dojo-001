namespace Dojo.Bakery.Transaction.Infra.Data.Configuration;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ConfigureBase();
        builder.ConfigureAuditable();
        builder.ToTable("Client", "Transactions");
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Documento).IsRequired().HasMaxLength(50);
        builder.Property(x => x.DocumentTypeId).IsRequired();
        builder.Property(x => x.Address).IsRequired().HasMaxLength(50);
        builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
    }
}
