using Dojo.Bakery.Transaction.Application.DTOs.Orders;
using MediatR;

namespace Dojo.Bakery.Transaction.Application.Queries.Orders
{
    public class GetAllOrdersQuery: IRequest<List<OrdersDto>>
    {

    }
}
