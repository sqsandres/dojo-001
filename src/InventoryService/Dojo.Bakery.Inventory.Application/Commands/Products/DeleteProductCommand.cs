using MediatR;

namespace Dojo.Bakery.Inventory.Application.Commands.Products
{
    public class DeleteProductCommand : IRequest<Guid>
    {
        public Guid ProductId { get; set; }
    }
}
