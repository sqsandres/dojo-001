namespace Dojo.Bakery.Transaction.Application.DTOs.Sell
{
    public class SellItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid SellId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }

}
