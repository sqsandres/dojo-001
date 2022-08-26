using Dojo.Bakery.BuildingBlocks.Commons;
using Dojo.Bakery.BuildingBlocks.Commons.Repositories;
using Dojo.Bakery.Inventory.Application.Commands.Category;
using Dojo.Bakery.Inventory.Infra.DataContract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dojo.Bakery.Inventory.Application.Handlers.Category
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, MediatR.Unit>
    {
        private readonly ILogger<DeleteCategoryCommandHandler> _logger;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCategoryCommandHandler(ILogger<DeleteCategoryCommandHandler> logger, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<MediatR.Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            DomainExceptionValidation.When(request == null || request.Id == Guid.Empty, "Delete Id data is required");
            Domain.Category Category = await _categoryRepository.GetByIdAsync(request.Id);
            DomainExceptionValidation.When(Category == null, "Category not found");
            await _categoryRepository.RemoveEntityAsync(Category);
            await _unitOfWork.CommitAsync();
            return MediatR.Unit.Value;
        }
    }
}
