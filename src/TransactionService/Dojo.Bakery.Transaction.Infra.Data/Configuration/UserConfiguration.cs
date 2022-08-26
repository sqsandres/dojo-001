using Dojo.Bakery.Transaction.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dojo.Bakery.Transaction.Infra.Data.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ConfigureBase();
            builder.ConfigureAuditable();
            builder.ToTable("User", "Transactions");
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        }
    }
}
