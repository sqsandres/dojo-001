
namespace Dojo.Bakery.Transaction.Application.Handlers.Categorys;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
{
    private readonly ILogger<GetCategoryByIdQueryHandler> _logger;
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryByIdQueryHandler(ILogger<GetCategoryByIdQueryHandler> logger, ICategoryRepository categoryRepository)
    {
        _logger = logger;
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(request.Id.ToString()), "Category Id is required");

        Category query = await _categoryRepository.GetByIdAsync(request.Id);

        DomainExceptionValidation.When(query == null, "Category not found");

        CategoryDto category = new CategoryDto()
        {
            Id = query.Id,
            Name = query.Name
        };

        return category;
    }
}
