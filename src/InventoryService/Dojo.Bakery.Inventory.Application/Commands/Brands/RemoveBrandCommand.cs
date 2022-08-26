namespace Dojo.Bakery.Inventory.Application.Commands.Brands;

public class RemoveBrandCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
}
