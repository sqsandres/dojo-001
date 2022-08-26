using Dojo.Bakery.Inventory.Application.DTOs.Products;
using MediatR;

namespace Dojo.Bakery.Inventory.Application.Commands.Products
{
    public class UpdateProductCommand : IRequest<Guid>
    {
        public Guid ProductId { get; set; }
        public ProductDto Item { get; set; }

    }
}
