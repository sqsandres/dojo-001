namespace Dojo.Bakery.Transaction.Application.Handlers.Products;

public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand, Guid>
{
    private readonly ILogger<RemoveProductCommandHandler> _logger;
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveProductCommandHandler(ILogger<RemoveProductCommandHandler> logger, IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
    {
        DomainExceptionValidation.When(request == null || request.Id == null, "Product data is required");
        Product product = await _productRepository.GetByIdAsync(request.Id);

        if(product == null) DomainExceptionValidation.When(product == null, "Product not found");

        await _productRepository.RemoveEntityAsync(request.Id);
        await _unitOfWork.CommitAsync();
        return request.Id;
    }
}
