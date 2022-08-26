using Dojo.Bakery.Transaction.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dojo.Bakery.Transaction.Infra.Data.Configuration
{
    internal class SellConfiguration : IEntityTypeConfiguration<Sell>
    {
        public void Configure(EntityTypeBuilder<Sell> builder)
        {
            builder.ConfigureBase();
            builder.ConfigureAuditable();
            builder.ToTable("Sale", "Transactions");
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Number).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Total).IsRequired();
            builder.Property(x => x.ClientId).IsRequired();
        }
    }
}
