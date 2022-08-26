namespace Dojo.Bakery.Transaction.Application.Queries.Suppliers;

public class GetSupplierByIdQuery : IRequest<SupplierDto>
{
    public Guid Id { get; set; }
}
