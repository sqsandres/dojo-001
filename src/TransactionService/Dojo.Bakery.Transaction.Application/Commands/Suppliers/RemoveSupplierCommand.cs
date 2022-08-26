namespace Dojo.Bakery.Transaction.Application.Commands.Suppliers;

public class RemoveSupplierCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
}
