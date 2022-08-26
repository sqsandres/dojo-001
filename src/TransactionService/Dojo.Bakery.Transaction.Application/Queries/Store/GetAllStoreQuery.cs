using Dojo.Bakery.Transaction.Application.DTOs.Store;
using MediatR;

namespace Dojo.Bakery.Transaction.Application.Queries.Store
{
    public class GetAllStoreQuery : IRequest<List<StoreDto>>
    {
    }
}
