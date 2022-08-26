namespace Dojo.Bakery.Transaction.Application.Commands.Product;

public class RemoveProductCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
}
