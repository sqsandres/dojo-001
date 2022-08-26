using Dojo.Bakery.Transaction.Application.DTOs.Orders;
using MediatR;

namespace Dojo.Bakery.Transaction.Application.Commands.Orders
{
    public class UpdateOrderCommand: IRequest<Guid>
    {
        public Guid OrderId { get; set; }
        public OrdersDto Item { get; set; }

    }
}
