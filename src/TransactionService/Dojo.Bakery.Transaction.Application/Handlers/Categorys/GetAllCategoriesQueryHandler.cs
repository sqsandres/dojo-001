
namespace Dojo.Bakery.Transaction.Application.Handlers.Categorys;

public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryDto>>
{
    private readonly ILogger<GetAllCategoriesQueryHandler> _logger;
    private readonly ICategoryRepository _categoryRepository;

    public GetAllCategoriesQueryHandler(ILogger<GetAllCategoriesQueryHandler> logger, ICategoryRepository categoryRepository)
    {
        _logger = logger;
        _categoryRepository = categoryRepository;
    }

    public async Task<List<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Category> query = from i in await _categoryRepository.GetEntitiesAsync()
                                      orderby i.Name
                                      select i;
        DomainExceptionValidation.When(query == null, "There is not categories");
        List<CategoryDto> categories = new List<CategoryDto>();
        foreach (Category item in query)
        {
            categories.Add(new CategoryDto()
            {
                Id = item.Id,
                Name = item.Name
            });
        }
        return categories;
    }
}
