
namespace Dojo.Bakery.Inventory.Application.Commands.Brands;

public class UpdateBrandCommand : IRequest<Guid>
{
    public BrandDto Item { get; set; }
}
