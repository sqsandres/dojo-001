namespace Dojo.Bakery.Transaction.Application.Queries.Categorys;

public class GetCategoryByIdQuery : IRequest<CategoryDto>
{
    public Guid Id { get; set; }
}
