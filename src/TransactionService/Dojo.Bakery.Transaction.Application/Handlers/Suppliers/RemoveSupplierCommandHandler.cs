
namespace Dojo.Bakery.Transaction.Application.Handlers.Suppliers;

public class RemoveSupplierCommandHandler : IRequestHandler<RemoveSupplierCommand, Guid>
{
    private readonly ILogger<CreateSupplierCommandHandler> _logger;
    private readonly ISupplierRepository _supplierRepository;
    private readonly IUnitOfWork _unitOfWork;
    public RemoveSupplierCommandHandler(ILogger<CreateSupplierCommandHandler> logger, ISupplierRepository supplierRepository, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _supplierRepository = supplierRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(RemoveSupplierCommand request, CancellationToken cancellationToken)
    {
        DomainExceptionValidation.When(request == null || request.Id == null, "Supplier data is required");
        Client supplier = await _supplierRepository.GetByIdAsync(request.Id);

        if (supplier == null) DomainExceptionValidation.When(supplier == null, "Supplier not found");

        await _supplierRepository.RemoveEntityAsync(request.Id);
        await _unitOfWork.CommitAsync();
        return request.Id;
    }
}
