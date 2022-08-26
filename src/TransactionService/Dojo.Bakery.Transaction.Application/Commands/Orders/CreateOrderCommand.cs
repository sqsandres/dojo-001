using Dojo.Bakery.Transaction.Application.DTOs.Orders;
using MediatR;

namespace Dojo.Bakery.Transaction.Application.Commands.Orders
{
    public class CreateOrderCommand: IRequest<Guid>
    {
        public OrdersDto Item { get; set; }

    }
}
