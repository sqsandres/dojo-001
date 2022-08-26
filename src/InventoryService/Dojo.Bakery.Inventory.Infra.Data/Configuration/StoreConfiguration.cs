using Dojo.Bakery.Inventory.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dojo.Bakery.Inventory.Infra.Data.Configuration
{
    internal class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ConfigureBase();
            builder.ConfigureAuditable();
            builder.ToTable("Store", "Inventory");
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.DocumentNumber).IsRequired().HasMaxLength(50);
        }
    }
}
