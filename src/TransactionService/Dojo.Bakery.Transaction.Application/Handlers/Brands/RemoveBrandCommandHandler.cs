namespace Dojo.Bakery.Transaction.Application.Handlers.Brands;

public class RemoveBrandCommandHandler : IRequestHandler<RemoveBrandCommand, Guid>
{
    private readonly ILogger<RemoveBrandCommandHandler> _logger;
    private readonly IBrandRepository _brandRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveBrandCommandHandler(ILogger<RemoveBrandCommandHandler> logger, IBrandRepository brandRepository, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _brandRepository = brandRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(RemoveBrandCommand request, CancellationToken cancellationToken)
    {
        DomainExceptionValidation.When(request == null || request.Id == Guid.Empty, "Brand data is required");
        Brand brand = await _brandRepository.GetByIdAsync(request.Id);

        if (brand == null) DomainExceptionValidation.When(brand == null, "Brand not found");

        await _brandRepository.RemoveEntityAsync(request.Id);
        await _unitOfWork.CommitAsync();
        return request.Id;
    }
}
