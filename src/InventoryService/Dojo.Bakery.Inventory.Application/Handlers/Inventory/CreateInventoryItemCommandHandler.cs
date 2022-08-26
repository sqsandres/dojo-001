using Dojo.Bakery.BuildingBlocks.Commons;
using Dojo.Bakery.BuildingBlocks.Commons.Repositories;
using Dojo.Bakery.Inventory.Application.Commands.Inventory;
using Dojo.Bakery.Inventory.Infra.DataContract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dojo.Bakery.Inventory.Application.Handlers.Inventory
{
    public class CreateInventoryItemCommandHandler : IRequestHandler<CreateInventoryItemCommand, Guid>
    {
        private readonly ILogger<CreateInventoryItemCommandHandler> _logger;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateInventoryItemCommandHandler(ILogger<CreateInventoryItemCommandHandler> logger, IInventoryRepository inventoryRepository, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _inventoryRepository = inventoryRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateInventoryItemCommand request, CancellationToken cancellationToken)
        {
            DomainExceptionValidation.When(request == null || request.Item == null, "Creation data is required");
            Domain.Entities.Inventory inventory = new Domain.Entities.Inventory(request.Item.ProductId, request.Item.StoreId, request.Item.Stock);
            await _inventoryRepository.CreateAsync(inventory);
            await _unitOfWork.CommitAsync();
            return inventory.Id;
        }
    }
}
