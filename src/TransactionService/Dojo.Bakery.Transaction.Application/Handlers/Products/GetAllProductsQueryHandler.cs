namespace Dojo.Bakery.Transaction.Application.Handlers.Products;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
{
    private readonly ILogger<GetAllProductsQueryHandler> _logger;
    private readonly IProductRepository _productRepository;
    public GetAllProductsQueryHandler(ILogger<GetAllProductsQueryHandler> logger, IProductRepository productRepository)
    {
        _logger = logger;
        _productRepository = productRepository;
    }
    public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Product> query = from i in await _productRepository.GetEntitiesAsync()
                                     orderby i.Name
                                     select i;

        DomainExceptionValidation.When(query.Count() <= 0 || query == null, "There is not products");

        List<ProductDto> list = new List<ProductDto>();
        foreach (Product item in query.ToList())
        {
            list.Add(new ProductDto()
            {
                Id = item.Id,
                Name = item.Name,
                UnitId = item.UnitId,
                BrandI = item.BrandId,
                CategoryId = item.CategoryId,
                UnitPrice = item.UnitPrice,
                QR = item.QR
            });
        }
        return list;
    }
}
