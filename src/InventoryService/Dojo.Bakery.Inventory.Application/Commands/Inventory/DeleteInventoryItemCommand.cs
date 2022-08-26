using MediatR;

namespace Dojo.Bakery.Inventory.Application.Commands.Inventory
{
    public class DeleteInventoryItemCommand: IRequest<Guid>
    {
        public Guid InventoryId { get; set; }
    }
}
