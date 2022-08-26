namespace Dojo.Bakery.Transaction.Application.Commands.Brands;

public class UpdateBrandCommand : IRequest<Guid>
{
    public BrandDto Item { get; set; }
}
