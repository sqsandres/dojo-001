namespace Dojo.Bakery.Transaction.Application.DTOs.Orders
{
    public class OrdersDto
    {
        public Guid Id { get; set; }
        public Guid VendorId { get; set; }
        public decimal Total { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime DeliveryDate { get; set; }
        public List<OrderDetailDto> Details { get; set; }
    }
}
