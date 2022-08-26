namespace Dojo.Bakery.Transaction.Application.Commands.Categorys;

public class UpdateCategoryCommand : IRequest<Guid>
{
    public CategoryDto Item { get; set; }
}
