

namespace Dojo.Bakery.Transaction.Application.Handlers.Suppliers;

public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, Guid>
{
    private readonly ILogger<CreateSupplierCommandHandler> _logger;
    private readonly ISupplierRepository _supplierRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateSupplierCommandHandler(ILogger<CreateSupplierCommandHandler> logger, ISupplierRepository supplierRepository, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _supplierRepository = supplierRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
    {
        DomainExceptionValidation.When(request == null || request.Item == null, "Supplier Creation data is required");
        Supplier supplier = new Supplier(
            request.Item.Name,
            request.Item.DocumentId,
            request.Item.DocumentTypeId,
            request.Item.Address,
            request.Item.PhoneNumber,
            request.Item.Email
            );
        await _supplierRepository.CreateAsync(supplier);
        await _unitOfWork.CommitAsync();
        return supplier.Id;
    }
}
