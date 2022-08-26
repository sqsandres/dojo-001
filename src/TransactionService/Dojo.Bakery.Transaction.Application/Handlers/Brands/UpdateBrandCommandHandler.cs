namespace Dojo.Bakery.Transaction.Application.Handlers.Brands;

public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, Guid>
{
    private readonly ILogger<UpdateBrandCommandHandler> _logger;
    private readonly IBrandRepository _brandRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBrandCommandHandler(ILogger<UpdateBrandCommandHandler> logger, IBrandRepository brandRepository, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _brandRepository = brandRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
    {
        DomainExceptionValidation.When(request == null || request.Item == null, "Update Brand data is required");
        Brand brand = await _brandRepository.GetByIdAsync(request.Item.Id);
        brand.ChangeName(request.Item.Name);
        await _brandRepository.UpdateAsync(brand);
        await _unitOfWork.CommitAsync();
        return brand.Id;
    }
}
