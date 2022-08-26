using Dojo.Bakery.Inventory.Application.DTOs.Inventory;
using MediatR;

namespace Dojo.Bakery.Inventory.Application.Commands.Inventory
{
    public class UpdateStockCommand: IRequest<bool>
    {
        public Guid InventoryId { get; set; }
        public StockDto StockDto{ get; set; }
    }
}
