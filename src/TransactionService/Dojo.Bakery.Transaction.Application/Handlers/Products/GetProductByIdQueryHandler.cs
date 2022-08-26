
namespace Dojo.Bakery.Transaction.Application.Handlers.Products;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    private readonly ILogger<GetProductByIdQueryHandler> _logger;
    private readonly IProductRepository _productRepository;

    public GetProductByIdQueryHandler(ILogger<GetProductByIdQueryHandler> logger, IProductRepository productRepository)
    {
        _logger = logger;
        _productRepository = productRepository;
    }

    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {

        Product query = await _productRepository.GetByIdAsync(request.Id);

        DomainExceptionValidation.When(query == null, "Product not found");
        ProductDto product = new ProductDto
        {
            Id = query.Id,
            Name = query.Name,
            UnitPrice = query.UnitPrice,
            UnitId = query.UnitId,
            CategoryId = query.CategoryId,
            BrandI = query.BrandId,
            QR = query.QR
        };
        return product;
                        
    }
}
