using Dojo.Bakery.BuildingBlocks.Commons;

namespace Dojo.Bakery.Transaction.Domain
{
    public class Order : AggregateRoot
    {
        public Order(Guid vendorId, decimal total, string invoiceNumber, DateTime deliveryDate)
        {
            ValidateDomain(vendorId, total, invoiceNumber, deliveryDate);
            Id = IdentityGenerator.NewSequentialGuid();
        }

        private void ValidateDomain(Guid vendorId, decimal total, string invoiceNumber, DateTime deliveryDate)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(invoiceNumber), DomainExceptionValidation.RequiredValueMessage, nameof(invoiceNumber));
            DomainExceptionValidation.When(vendorId == Guid.Empty, DomainExceptionValidation.RequiredValueMessage, nameof(vendorId));
            DomainExceptionValidation.When(total < 1, "Invalid total. The total must be greater than 0");
            //DomainExceptionValidation.When(details != null && details.Any(), "there must be at least one product in the order");
            VendorId = vendorId;
            Total = total;
            InvoiceNumber = invoiceNumber;
            DeliveryDate = deliveryDate;
            //Details = details;
        }

        public Guid VendorId { get; private set; }
        public decimal Total { get; private set; }
        public string InvoiceNumber { get; private set; }
        public DateTime DeliveryDate { get; private set; }
        public List<OrderDetail> Details { get; private set; }

        public void Updated(Guid vendorId, decimal total, string invoiceNumber, DateTime deliveryDate)
        {
            ValidateDomain(vendorId, total, invoiceNumber, deliveryDate);
        }
    }
}
