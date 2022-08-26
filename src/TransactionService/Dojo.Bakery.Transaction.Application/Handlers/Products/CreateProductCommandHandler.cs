
namespace Dojo.Bakery.Transaction.Application.Handlers.Products;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly ILogger<CreateProductCommandHandler> _logger;
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateProductCommandHandler(ILogger<CreateProductCommandHandler> logger, IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        DomainExceptionValidation.When(request == null || request.Item == null, "Creation data is required");


        Product product = new(request.Item.Name,
                            request.Item.UnitPrice,
                            request.Item.UnitId,
                            request.Item.CategoryId,
                            request.Item.BrandI,
                            request.Item.QR);
        
        await _productRepository.CreateAsync(product);
        await _unitOfWork.CommitAsync();
        return product.Id;
        
    }
}
