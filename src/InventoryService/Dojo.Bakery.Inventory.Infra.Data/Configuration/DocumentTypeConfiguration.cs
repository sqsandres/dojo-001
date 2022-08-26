using Dojo.Bakery.Inventory.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dojo.Bakery.Inventory.Infra.Data.Configuration
{
    internal class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            builder.ConfigureBase();
            builder.ConfigureAuditable();
            builder.ToTable("DocumentType", "Inventory");
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.HasData(new[] {
                new { Name="NIT",
                    Id=new Guid("cee1dce9-443f-4dac-a249-71889b4b8f93"),
                    IsActive=true,
                    CreatedOn=new DateTime(2022, 1, 1)
                },
                new { Name="DNI",
                    Id=new Guid("4cb9413d-a0c1-4b29-bc78-015130b756d2"),
                    IsActive=true,
                    CreatedOn=new DateTime(2022, 1, 1)
                }
            });
        }
    }
}
