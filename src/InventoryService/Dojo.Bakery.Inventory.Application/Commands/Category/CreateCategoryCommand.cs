using Dojo.Bakery.Inventory.Application.DTOs.Category;
using MediatR;

namespace Dojo.Bakery.Inventory.Application.Commands.Category
{
    public class CreateCategoryCommand : IRequest<Guid>
    {
        public CategoryDto Item { get; set; }
    }
}
