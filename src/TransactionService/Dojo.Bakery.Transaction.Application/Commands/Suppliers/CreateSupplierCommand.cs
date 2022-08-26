
namespace Dojo.Bakery.Transaction.Application.Commands.Suppliers;

public class CreateSupplierCommand : IRequest<Guid>
{
    public SupplierDto Item { get; set; }
}
