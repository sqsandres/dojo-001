using Dojo.Bakery.Inventory.Application.DTOs.Products;
using MediatR;

namespace Dojo.Bakery.Inventory.Application.Commands.Products
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public ProductDto Item { get; set; }
    }
}
