using Dojo.Bakery.Transaction.Application.DTOs.Sell;
using MediatR;

namespace Dojo.Bakery.Transaction.Application.Queries.Sell
{
    public class GetAllSellQuery : IRequest<List<SellDto>>
    {
    }
}
