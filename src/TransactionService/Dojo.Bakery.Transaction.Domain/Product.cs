namespace Dojo.Bakery.Transaction.Domain;

public sealed class Product : AggregateRoot
{
    public string Name { get; private set; }

    public decimal UnitPrice { get; private set; }

    public Guid UnitId { get; private set; }

    public Guid CategoryId { get; private set; }

    public Guid BrandId { get; private set; }
    public string QR { get; private set; }

    private Product() { }

    public Product(string name, decimal unitPrice, Guid unitId, Guid categoryId, Guid brandId, string qR)
    {
        ValidateDomain(name, unitPrice, unitId, categoryId, brandId, qR);
        Id = IdentityGenerator.NewSequentialGuid();
    }
    
    public void Update(string name, decimal unitPrice, Guid unitId, Guid categoryId, Guid brandId, string qr)
    {
        ValidateDomain(name, unitPrice, unitId, categoryId, brandId, qr);
    }

    private void ValidateDomain(string name, decimal unitPrice, Guid unitId, Guid categoryId, Guid brandId, string qr)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), DomainExceptionValidation.RequiredValueMessage, nameof(name));

        DomainExceptionValidation.When(unitId == Guid.Empty, DomainExceptionValidation.RequiredValueMessage,nameof(unitId));
        DomainExceptionValidation.When(categoryId == Guid.Empty, DomainExceptionValidation.RequiredValueMessage,nameof(categoryId));
        DomainExceptionValidation.When(brandId == Guid.Empty, DomainExceptionValidation.RequiredValueMessage,nameof(brandId));
        DomainExceptionValidation.When(unitPrice < 0, DomainExceptionValidation.RequiredValueMessage,nameof(unitPrice));

        DomainExceptionValidation.When(string.IsNullOrEmpty(qr), DomainExceptionValidation.RequiredValueMessage,nameof(qr));

        Name = name;
        UnitPrice = unitPrice;
        UnitId = unitId;
        CategoryId = categoryId;
        BrandId = brandId;
        QR = qr;       
    }
}
