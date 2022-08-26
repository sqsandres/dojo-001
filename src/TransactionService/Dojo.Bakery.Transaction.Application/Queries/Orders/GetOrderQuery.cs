using Dojo.Bakery.Transaction.Application.DTOs.Orders;
using MediatR;

namespace Dojo.Bakery.Transaction.Application.Queries.Orders
{
    public class GetOrderQuery : IRequest<OrdersDto>
    {
        public Guid OrderId { get; set; }
    }
}
