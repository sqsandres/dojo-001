using Dojo.Bakery.Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dojo.Bakery.Inventory.Infra.Data.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ConfigureBase();
            builder.ConfigureAuditable();
            builder.ToTable("Product", "Inventory");
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.QRCode).IsRequired().HasMaxLength(100);
            builder.Property(x => x.BrandId).IsRequired();
            builder.Property(x => x.UnitId).IsRequired();
            builder.Property(x => x.CategoryId).IsRequired();

            builder.HasData(
                new[]
                {
                    new {
                        Id = new Guid("3FA85F64-5717-4562-B3FC-2C963F66AFA6"),
                        Name = "Pan Ocanero",
                        QRCode = "1234",
                        UnitId = new Guid("ab994361-1dee-4667-9f91-e46a3641ed6e"),
                        CategoryId = new Guid("7c684031-2232-4c10-9c03-790db1c06bf4"),
                        BrandId = new Guid("3aad1a96-9d1a-432a-b867-09f27ccbc7ab"),
                        IsActive = true,
                        CreatedOn = DateTime.Now,
                        UpdatedOn = DateTime.Now
                    }
                }
            );
        }
    }
}
