using Dojo.Bakery.Inventory.Application.DTOs.Products;
using MediatR;

namespace Dojo.Bakery.Inventory.Application.Queries.Products
{
    public class GetAllProductsQuery : IRequest<List<ProductDto>>
    {
    }
}
