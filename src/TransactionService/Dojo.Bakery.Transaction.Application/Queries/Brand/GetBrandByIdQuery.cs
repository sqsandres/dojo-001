namespace Dojo.Bakery.Transaction.Application.Queries.Brand;

public class GetBrandByIdQuery : IRequest<BrandDto>
{
    public Guid Id { get; set; }
}
