
namespace Dojo.Bakery.Transaction.Application.Handlers.Suppliers;

public class GetAllSuppliersQueryHandler : IRequestHandler<GetAllSuppliersQuery, List<SupplierDto>>
{
    private readonly ILogger<CreateSupplierCommandHandler> _logger;
    private readonly ISupplierRepository _supplierRepository;
    public GetAllSuppliersQueryHandler(ILogger<CreateSupplierCommandHandler> logger, ISupplierRepository supplierRepository)
    {
        _logger = logger;
        _supplierRepository = supplierRepository;
    }

    public async Task<List<SupplierDto>> Handle(GetAllSuppliersQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Client> query = from spl in await _supplierRepository.GetEntitiesAsync()
                                        orderby spl.Name
                                        select spl;
        DomainExceptionValidation.When(query == null, "There is not Suppliers");

        List<SupplierDto> suppliers = new List<SupplierDto>();
        foreach (Client item in query)
        {
            suppliers.Add(new SupplierDto
            {
                Id = item.Id,
                Name = item.Name,
                DocumentId = item.DocumentId,
                DocumentTypeId = item.DocumentTypeId,
                Address = item.Address,
                PhoneNumber = item.PhoneNumber,
                Email = item.Email
            });
        }
        return suppliers;
    }
}
