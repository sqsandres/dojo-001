using Dojo.Bakery.BuildingBlocks.Commons;

namespace Dojo.Bakery.Inventory.Domain.Entities
{
    public class Product : AggregateRoot
    {
        public string Name { get; private set; }
        public string QRCode { get; private set; }
        public Guid UnitId { get; private set; }
        public Guid CategoryId { get; private set; }
        public Guid BrandId { get; private set; }
        private Product() { }
        public Product(Guid productId, string qrCode, string name, Guid unitId, Guid categoryId, Guid brandId)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(qrCode), DomainExceptionValidation.RequiredValueMessage, nameof(qrCode));
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), DomainExceptionValidation.RequiredValueMessage, nameof(name));
            DomainExceptionValidation.When(ValidateGuid(productId), DomainExceptionValidation.RequiredValueMessage, nameof(productId));
            DomainExceptionValidation.When(ValidateGuid(unitId), DomainExceptionValidation.RequiredValueMessage, nameof(unitId));
            DomainExceptionValidation.When(ValidateGuid(categoryId), DomainExceptionValidation.RequiredValueMessage, nameof(categoryId));
            DomainExceptionValidation.When(ValidateGuid(brandId), DomainExceptionValidation.RequiredValueMessage, nameof(brandId));
            Name = name;
            Id = productId;
            QRCode = qrCode;    
            UnitId = unitId;
            CategoryId = categoryId;
            BrandId = brandId;
        }

        public void ModifyProductName(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), $"{nameof(name)} cannot be null or empty");
            Name = name;
        }

        public void ModifyQRCode(string qrCode)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(qrCode), $"{nameof(qrCode)} cannot be null or empty");
            QRCode = qrCode;
        }

        public void ChangeUnit(Guid id)
        {
            DomainExceptionValidation.When(id == Guid.Empty, "The Unit Id is required");
            UnitId = id;
        }

        public void ChangeCategory(Guid id)
        {
            DomainExceptionValidation.When(id == Guid.Empty, "The Category Id is required");
            CategoryId = id;
        }

        public void ChangeBrand(Guid id)
        {
            DomainExceptionValidation.When(id == Guid.Empty, "The Brand Id is required");
            BrandId = id;
        }

        private bool ValidateGuid(Guid id) => id == Guid.Empty;
    }
}
