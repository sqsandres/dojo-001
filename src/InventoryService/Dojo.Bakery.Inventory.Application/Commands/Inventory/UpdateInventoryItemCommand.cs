using Dojo.Bakery.Inventory.Application.DTOs.Inventory;
using MediatR;

namespace Dojo.Bakery.Inventory.Application.Commands.Inventory
{
    public class UpdateInventoryItemCommand: IRequest<Guid>
    {
        public Guid InventoryId { get; set; }
        public InventoryDto Item { get; set; }
    }
}
