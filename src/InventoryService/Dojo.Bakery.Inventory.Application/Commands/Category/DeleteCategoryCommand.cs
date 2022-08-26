using Dojo.Bakery.Inventory.Application.DTOs.Category;
using MediatR;

namespace Dojo.Bakery.Inventory.Application.Commands.Category
{
    public class DeleteCategoryCommand : IRequest<MediatR.Unit>
    {
        public Guid Id { get; set; }
    }
}
