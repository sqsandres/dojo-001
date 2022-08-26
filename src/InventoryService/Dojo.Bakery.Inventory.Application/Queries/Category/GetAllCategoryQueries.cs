using Dojo.Bakery.Inventory.Application.DTOs.Category;
using MediatR;

namespace Dojo.Bakery.Inventory.Application.Queries.Category
{
    public class GetAllCategoryQuery : IRequest<List<CategoryDto>>
    {
    }
}
