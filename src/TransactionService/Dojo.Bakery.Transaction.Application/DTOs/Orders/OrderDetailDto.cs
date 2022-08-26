namespace Dojo.Bakery.Transaction.Application.DTOs.Orders
{
    public class OrderDetailDto
    {
        public Guid OrderId { get; set; }
        public Guid ProducId { get; set; }
        public short Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
    }
}