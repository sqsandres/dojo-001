

namespace Dojo.Bakery.Transaction.Application.Handlers.Brands;

public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, Guid>
{
    private readonly ILogger<CreateBrandCommandHandler> _logger;
    private readonly IBrandRepository _brandRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateBrandCommandHandler(ILogger<CreateBrandCommandHandler> logger, IBrandRepository brandRepository, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _brandRepository = brandRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        DomainExceptionValidation.When(request == null || request.Item == null, "Creation Brand data is required");
        Brand brand = new(request.Item.Name);
        await _brandRepository.CreateAsync(brand);
        await _unitOfWork.CommitAsync();
        return brand.Id;
    }
}
