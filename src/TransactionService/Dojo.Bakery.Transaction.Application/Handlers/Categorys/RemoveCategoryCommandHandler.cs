namespace Dojo.Bakery.Transaction.Application.Handlers.Categorys;

public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand, Guid>
{
    private readonly ILogger<RemoveCategoryCommandHandler> _logger;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveCategoryCommandHandler(ILogger<RemoveCategoryCommandHandler> logger, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
    {
        DomainExceptionValidation.When(request == null || request.Id == null, "Category data is required");
        Category category = await _categoryRepository.GetByIdAsync(request.Id);

        if(category == null) DomainExceptionValidation.When(category == null, "Product not found");

        await _categoryRepository.RemoveEntityAsync(category);
        await _unitOfWork.CommitAsync();
        return request.Id;
    }
}
