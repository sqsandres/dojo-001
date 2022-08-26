using Dojo.Bakery.Transaction.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dojo.Bakery.Transaction.Infra.Data.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ConfigureBase();
            builder.ConfigureAuditable();
            builder.ToTable("Order", "Transactions");
            builder.Property(x => x.VendorId).IsRequired();
            builder.Property(x => x.Total).IsRequired().HasColumnType("decimal(10,2)");
            builder.Property(x => x.InvoiceNumber).IsRequired().HasMaxLength(100);
            builder.Property(x => x.DeliveryDate).IsRequired();
        }
    }
}
