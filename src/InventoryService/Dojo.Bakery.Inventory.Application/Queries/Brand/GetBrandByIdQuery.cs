namespace Dojo.Bakery.Inventory.Application.Queries.Brand;

public class GetBrandByIdQuery : IRequest<BrandDto>
{
    public Guid Id { get; set; }
}
