using Dojo.Bakery.Transaction.Application.DTOs.Store;
using MediatR;

namespace Dojo.Bakery.Transaction.Application.Commands.Store
{
    public class UpdateStoreCommand : IRequest<Guid>
    {
        public StoreDto Item { get; set; }
    }
}
