namespace Dojo.Bakery.Transaction.Application.Commands.Suppliers;

public class UpdateSupplierCommand : IRequest<Guid>
{
    public SupplierDto Item { get; set; }
}
