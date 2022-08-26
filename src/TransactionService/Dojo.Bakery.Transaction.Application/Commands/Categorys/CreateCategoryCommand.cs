

namespace Dojo.Bakery.Transaction.Application.Commands.Categorys;

public class CreateCategoryCommand : IRequest<Guid>
{
    public CategoryDto Item { get; set; }
}
