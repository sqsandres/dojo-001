

namespace Dojo.Bakery.Inventory.Application.Handlers.Brands;

public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, BrandDto>
{
    private readonly ILogger<GetBrandByIdQueryHandler> _logger;
    private readonly IBrandRepository _brandRepository;

    public GetBrandByIdQueryHandler(ILogger<GetBrandByIdQueryHandler> logger, IBrandRepository brandRepository)
    {
        _logger = logger;
        _brandRepository = brandRepository;
    }

    public async Task<BrandDto> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
    {
        Brand query = await _brandRepository.GetByIdAsync(request.Id);
        DomainExceptionValidation.When(query == null, "Brand not found");
        BrandDto brand = new BrandDto()
        {
            Id = query.Id,
            Name = query.Name
        };
        return brand;
    }
}
