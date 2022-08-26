using Dojo.Bakery.Transaction.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dojo.Bakery.Transaction.Infra.Data.Configuration
{
    internal class SellItemConfiguration : IEntityTypeConfiguration<SaleItem>
    {
        public void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            builder.ConfigureBase();
            builder.ConfigureAuditable();
            builder.ToTable("SaleItem", "Transactions");
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.SellId).IsRequired();
            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.UnitPrice).IsRequired();
            builder.Property(x => x.TotalPrice).IsRequired();
        }
    }
}
