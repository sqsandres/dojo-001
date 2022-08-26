using Dojo.Bakery.BuildingBlocks.Commons;

namespace Dojo.Bakery.Transaction.Domain
{
    public class SaleItem : AggregateRoot
    {
        public string Name { get; private set; }
        public Guid SellId { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal TotalPrice { get; private set; }
        private SaleItem() { }
        public SaleItem(string name, Guid sellId, Guid productId, int quantity, decimal unitPrice)
        {
            ValidateDomain(name, sellId, productId, quantity, unitPrice);
            Id = IdentityGenerator.NewSequentialGuid();
        }

        public void Update(string name, Guid sellId, Guid productId, int quantity, decimal unitPrice)
        {
            ValidateDomain(name, sellId, productId, quantity, unitPrice);
        }
        private void ValidateDomain(string name, Guid sellId, Guid productId, int quantity, decimal unitPrice)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), DomainExceptionValidation.RequiredValueMessage, nameof(name));
            DomainExceptionValidation.When(sellId == Guid.Empty, DomainExceptionValidation.RequiredValueMessage, nameof(sellId));
            DomainExceptionValidation.When(productId == Guid.Empty, DomainExceptionValidation.RequiredValueMessage, nameof(productId));
            DomainExceptionValidation.When(quantity <= 0, DomainExceptionValidation.RequiredValueMessage, nameof(quantity));
            DomainExceptionValidation.When(unitPrice <= 0, DomainExceptionValidation.RequiredValueMessage, nameof(unitPrice));
            Name = name;
            SellId = sellId;
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            TotalPrice = quantity * unitPrice;
        }
    }
}
