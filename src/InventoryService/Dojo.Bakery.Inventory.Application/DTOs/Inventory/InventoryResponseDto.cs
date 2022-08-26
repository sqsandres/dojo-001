using Dojo.Bakery.Inventory.Application.DTOs.Products;

namespace Dojo.Bakery.Inventory.Application.DTOs.Inventory
{
    public class InventoryResponseDto
    {
        public Guid Id { get; set; }
        public int Stock { get; set; }
        public ProductDto Product { get; set; }
        //public Guid StoreId { get; set; }
        //public string StoreName { get; set; }
    }
}
