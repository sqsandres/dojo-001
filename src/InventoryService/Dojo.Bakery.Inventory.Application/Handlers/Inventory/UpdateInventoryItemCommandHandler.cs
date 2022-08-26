using Dojo.Bakery.BuildingBlocks.Commons;
using Dojo.Bakery.BuildingBlocks.Commons.Repositories;
using Dojo.Bakery.Inventory.Application.Commands.Inventory;
using Dojo.Bakery.Inventory.Infra.DataContract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dojo.Bakery.Inventory.Application.Handlers.Inventory
{
    public class UpdateInventoryItemCommandHandler : IRequestHandler<UpdateInventoryItemCommand, Guid>
    {
        private readonly ILogger<UpdateInventoryItemCommandHandler> _logger;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateInventoryItemCommandHandler(ILogger<UpdateInventoryItemCommandHandler> logger, IInventoryRepository inventoryRepository, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _inventoryRepository = inventoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(UpdateInventoryItemCommand request, CancellationToken cancellationToken)
        {
            DomainExceptionValidation.When(request == null, "The inventory Id and inventory data are required");
            DomainExceptionValidation.When(request.InventoryId == Guid.Empty, "The inventory Id is required");
            DomainExceptionValidation.When(request.Item == null, "The inventory data is required");

            Domain.Entities.Inventory inventory = await _inventoryRepository.GetByIdAsync(request.InventoryId);
            DomainExceptionValidation.When(inventory == null, $"{request.InventoryId}: Inventory item didn't find");
            inventory.ChangeProductId(request.Item.ProductId);
            inventory.ChangeStoreId(request.Item.StoreId);
            await _unitOfWork.CommitAsync();
            return inventory.Id;
        }
    }
}
