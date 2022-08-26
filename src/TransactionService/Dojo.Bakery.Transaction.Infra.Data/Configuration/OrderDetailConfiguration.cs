using Dojo.Bakery.Transaction.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dojo.Bakery.Transaction.Infra.Data.Configuration
{
    internal class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ConfigureBase();
            builder.ConfigureAuditable();
            builder.ToTable("OrderDetail", "Transactions");
            builder.Property(x => x.OrderId).IsRequired();
            builder.Property(x => x.ProducId).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.UnitPrice).IsRequired().HasColumnType("decimal(10,2)");
            builder.Property(x => x.Total).IsRequired().HasColumnType("decimal(10,2)");

        }
    }
}
