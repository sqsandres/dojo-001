using Dojo.Bakery.BuildingBlocks.Commons;
using Dojo.Bakery.BuildingBlocks.Commons.Repositories;
using Dojo.Bakery.Inventory.Application.Commands.Category;
using Dojo.Bakery.Inventory.Domain;
using Dojo.Bakery.Inventory.Infra.DataContract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dojo.Bakery.Inventory.Application.Handlers.Category
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly ILogger<CreateCategoryCommandHandler> _logger;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateCategoryCommandHandler(ILogger<CreateCategoryCommandHandler> logger, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            DomainExceptionValidation.When(request == null || request.Item == null, "Creation data is required");
            Domain.Category category = new Domain.Category(request.Item.Name);
            await _categoryRepository.CreateAsync(category);
            await _unitOfWork.CommitAsync();
            return category.Id;
        }
    }
}
