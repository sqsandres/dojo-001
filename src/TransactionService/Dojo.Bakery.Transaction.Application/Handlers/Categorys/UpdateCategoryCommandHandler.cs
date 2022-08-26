namespace Dojo.Bakery.Transaction.Application.Handlers.Categorys;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Guid>
{
    private readonly ILogger<UpdateCategoryCommandHandler> _logger;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryCommandHandler(ILogger<UpdateCategoryCommandHandler> logger, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        DomainExceptionValidation.When(request == null || request.Item == null, "Update data is required");

        Category category = new(request.Item.Name);
        await _categoryRepository.UpdateAsync(category);
        await _unitOfWork.CommitAsync();
        return category.Id;
    }
}
