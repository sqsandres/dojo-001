using Dojo.Bakery.Security.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dojo.Bakery.Security.Infra.Data.Configuration
{
    internal class ApplicationRoleClaimConfiguration : IEntityTypeConfiguration<ApplicationRoleClaim>
    {
        public void Configure(EntityTypeBuilder<ApplicationRoleClaim> builder)
        {
            builder.ToTable("RoleClaim");
            builder.HasKey(x => x.Id);
        }
    }
}
