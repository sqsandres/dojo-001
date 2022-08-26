using Dojo.Bakery.Inventory.Application.DTOs.Inventory;
using MediatR;

namespace Dojo.Bakery.Inventory.Application.Commands.Inventory
{
    public class CreateInventoryItemCommand: IRequest<Guid>
    {
        public InventoryDto Item { get; set; }

    }
}
