
namespace Dojo.Bakery.Transaction.Application.DTOs.Products
{
    public class ProductDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

        public Guid UnitId { get; set; }

        public Guid CategoryId { get; set; }

        public Guid BrandI { get; set; }

        public string QR { get; set; }
    }
}

