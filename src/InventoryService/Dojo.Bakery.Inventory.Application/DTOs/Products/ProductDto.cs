namespace Dojo.Bakery.Inventory.Application.DTOs.Products
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string QRCode { get; set; }
        public Guid UnitId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
    }
}
