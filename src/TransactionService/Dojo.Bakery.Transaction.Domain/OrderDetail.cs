using Dojo.Bakery.BuildingBlocks.Commons;

namespace Dojo.Bakery.Transaction.Domain
{
    public class OrderDetail : AggregateRoot
    {
        public OrderDetail(Guid OrderId, Guid ProducId, short Quantity, decimal UnitPrice)
        {
            ValidateDomain(OrderId, ProducId, Quantity, UnitPrice);
            Id = IdentityGenerator.NewSequentialGuid();
        }

        private void ValidateDomain(Guid orderId, Guid producId, short quantity, decimal unitPrice)
        {
            DomainExceptionValidation.When(orderId == Guid.Empty, "Invalid orderId. orderId is required");
            DomainExceptionValidation.When(producId == Guid.Empty, "Invalid producId. producId is required");
            DomainExceptionValidation.When(quantity < 1, "Invalid quantity. The quantity must be greater than 0");
            DomainExceptionValidation.When(unitPrice < 1, "Invalid quantity. The quantity must be greater than 0");
            OrderId = orderId;
            ProducId = producId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Total = quantity*unitPrice;
        }

        public Guid OrderId { get; private set; }
        public Guid ProducId { get; private set; }
        public short Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Total { get; private set; }
    }
}
