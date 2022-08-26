
namespace Dojo.Bakery.Inventory.Application.Handlers.Brands;

public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQuery, List<BrandDto>>
{
    private readonly ILogger<GetAllBrandsQueryHandler> _logger;
    private readonly IBrandRepository _brandRepository;

    public GetAllBrandsQueryHandler(ILogger<GetAllBrandsQueryHandler> logger, IBrandRepository brandRepository)
    {
        _logger = logger;
        _brandRepository = brandRepository;
    }

    public async Task<List<BrandDto>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
    {
        
        IEnumerable<Brand> query = from i in await _brandRepository.GetEntitiesAsync()
                                      orderby i.Name
                                      select i;
        DomainExceptionValidation.When(query == null, "There is not brands");
        List<BrandDto> brands = new List<BrandDto>();
        foreach (Brand item in query)
        {
            brands.Add(new BrandDto()
            {
                Id = item.Id,
                Name = item.Name
            });
        }
        return brands;
    }
}
