using Dojo.Bakery.BuildingBlocks.Commons;
using Dojo.Bakery.BuildingBlocks.Commons.Repositories;
using Dojo.Bakery.Inventory.Application.Commands.Category;
using Dojo.Bakery.Inventory.Infra.DataContract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dojo.Bakery.Inventory.Application.Handlers.Category
{
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
            Domain.Category category = await _categoryRepository.GetByIdAsync(request.Item.Id);
            DomainExceptionValidation.When(category == null, "Category not found");
            category.ChangeName(category.Name);
            await _categoryRepository.UpdateAsync(category);
            await _unitOfWork.CommitAsync();
            return category.Id;
        }
    }
}
