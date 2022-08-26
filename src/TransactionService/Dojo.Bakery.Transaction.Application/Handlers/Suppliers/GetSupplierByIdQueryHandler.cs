namespace Dojo.Bakery.Transaction.Application.Handlers.Suppliers;

public class GetSupplierByIdQueryHandler : IRequestHandler<GetSupplierByIdQuery, SupplierDto>
{
    private readonly ILogger<GetSupplierByIdQueryHandler> _logger;
    private readonly ISupplierRepository _supplierRepository;

    public GetSupplierByIdQueryHandler(ILogger<GetSupplierByIdQueryHandler> logger, ISupplierRepository supplierRepository)
    {
        _logger = logger;
        _supplierRepository = supplierRepository;
    }

    public async Task<SupplierDto> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
    {
        Client query = await _supplierRepository.GetByIdAsync(request.Id);

        DomainExceptionValidation.When(query == null, "Supplier not found");

        SupplierDto supplier = new SupplierDto
        {
            Id = query.Id,
            Name = query.Name,
            DocumentId = query.DocumentId,
            DocumentTypeId = query.DocumentTypeId,
            Address = query.Address,
            PhoneNumber = query.PhoneNumber,
            Email = query.Email
        };
        return supplier;
    }
}
