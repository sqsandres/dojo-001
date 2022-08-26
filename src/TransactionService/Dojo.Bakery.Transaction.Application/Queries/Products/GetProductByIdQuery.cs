namespace Dojo.Bakery.Transaction.Application.Queries.Products;

public class GetProductByIdQuery : IRequest<ProductDto>
{
    public Guid Id { get; set; }
}
