namespace Dojo.Bakery.Transaction.Application.Handlers.Products;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Guid>
{
    private readonly ILogger<UpdateProductCommandHandler> _logger;
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateProductCommandHandler(ILogger<UpdateProductCommandHandler> logger, IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Guid> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        DomainExceptionValidation.When(request == null || request.Item == null, "Update data is required");

        Product product = new(request.Item.Name,
                            request.Item.UnitPrice,
                            request.Item.UnitId,
                            request.Item.CategoryId,
                            request.Item.BrandI,
                            request.Item.QR);
        await _productRepository.UpdateAsync(product);
        await _unitOfWork.CommitAsync();
        return product.Id;
    }
}
