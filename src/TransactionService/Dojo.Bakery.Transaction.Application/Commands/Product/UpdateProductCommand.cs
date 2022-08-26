namespace Dojo.Bakery.Transaction.Application.Commands.Product;

public class UpdateProductCommand : IRequest<Guid>
{
    public ProductDto Item { get; set; }
}
