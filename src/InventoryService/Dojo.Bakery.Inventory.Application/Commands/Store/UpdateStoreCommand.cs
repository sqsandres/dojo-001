using Dojo.Bakery.Inventory.Application.DTOs.Store;
using MediatR;

namespace Dojo.Bakery.Inventory.Application.Commands.Store
{
    public class UpdateStoreCommand : IRequest<Guid>
    {
        public StoreDto Item { get; set; }
    }
}
