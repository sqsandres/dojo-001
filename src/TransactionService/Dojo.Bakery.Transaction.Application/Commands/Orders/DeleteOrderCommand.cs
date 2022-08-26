using MediatR;

namespace Dojo.Bakery.Transaction.Application.Commands.Orders
{
    public class DeleteOrderCommand : IRequest<Guid>
    {
        public Guid OrderId { get; set; }
    }
}
