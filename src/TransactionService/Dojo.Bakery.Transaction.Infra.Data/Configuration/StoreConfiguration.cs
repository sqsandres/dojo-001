using Dojo.Bakery.Transaction.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dojo.Bakery.Transaction.Infra.Data.Configuration
{
    internal class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ConfigureBase();
            builder.ConfigureAuditable();
            builder.ToTable("Store", "Transactions");
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Address).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(50);
            builder.Property(x => x.City).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Country).IsRequired().HasMaxLength(50);
            builder.Property(x => x.DocumentNumber).IsRequired().HasMaxLength(50);
            builder.Property(x => x.OpenTime).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CloseTime).IsRequired().HasMaxLength(50);
        }
    }
}
