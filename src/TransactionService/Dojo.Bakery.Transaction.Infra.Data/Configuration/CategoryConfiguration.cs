namespace Dojo.Bakery.Transaction.Infra.Data.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ConfigureBase();
        builder.ConfigureAuditable();
        builder.ToTable("Category", "Transactions");
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
    }
}
