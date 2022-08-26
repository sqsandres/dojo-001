namespace Dojo.Bakery.Transaction.Application.Commands.Categorys;

public class RemoveCategoryCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
}
