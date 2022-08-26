using Dojo.Bakery.Inventory.Application.DTOs.Store;
using MediatR;

namespace Dojo.Bakery.Inventory.Application.Commands.Store
{
    public class DeleteStoreCommand : IRequest<MediatR.Unit>
    {
        public Guid Id { get; set; }
    }
}
