
namespace Dojo.Bakery.Transaction.Application.DTOs.Sell
{
    public class SellDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public decimal Total { get; set; }
        public Guid ClientId { get; set; }
        public IList<SellItemDto> Items { get; set; }
    }
}
