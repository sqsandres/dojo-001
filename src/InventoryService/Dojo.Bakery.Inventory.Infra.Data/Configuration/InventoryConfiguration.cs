using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dojo.Bakery.Inventory.Infra.Data.Configuration
{
    internal class InventoryConfiguration : IEntityTypeConfiguration<Domain.Entities.Inventory>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Inventory> builder)
        {
            builder.ConfigureBase();
            builder.ConfigureAuditable();
            builder.ToTable("Inventory", "Inventory");
            builder.Property(x => x.Stock).IsRequired();
            builder.Property(x => x.StoreId).IsRequired();
            builder.Property(x => x.ProductId).IsRequired();
        }
    }
}
