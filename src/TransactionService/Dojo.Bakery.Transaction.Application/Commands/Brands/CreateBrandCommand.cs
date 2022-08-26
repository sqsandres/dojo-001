namespace Dojo.Bakery.Transaction.Application.Commands.Brands;

public class CreateBrandCommand : IRequest<Guid>
{
    public BrandDto Item { get; set; }
}
