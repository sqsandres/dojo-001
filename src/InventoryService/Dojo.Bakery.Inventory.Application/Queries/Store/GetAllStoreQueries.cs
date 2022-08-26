using Dojo.Bakery.Inventory.Application.DTOs.Store;
using MediatR;

namespace Dojo.Bakery.Inventory.Application.Queries.Store
{
    public class GetAllStoreQuery : IRequest<List<StoreDto>>
    {
    }
}
