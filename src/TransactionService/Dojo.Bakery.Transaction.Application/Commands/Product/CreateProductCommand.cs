
namespace Dojo.Bakery.Transaction.Application.Commands.Product
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public ProductDto Item { get; set; }
    }
}
