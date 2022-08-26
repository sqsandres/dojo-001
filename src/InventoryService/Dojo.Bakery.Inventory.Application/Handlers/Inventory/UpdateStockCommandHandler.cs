using Dojo.Bakery.BuildingBlocks.Commons;
using Dojo.Bakery.BuildingBlocks.Commons.Repositories;
using Dojo.Bakery.Inventory.Application.Commands.Inventory;
using Dojo.Bakery.Inventory.Infra.DataContract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dojo.Bakery.Inventory.Application.Handlers.Inventory
{
    public class UpdateStockCommandHandler : IRequestHandler<UpdateStockCommand, bool>
    {
        private readonly ILogger<UpdateStockCommandHandler> _logger;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IUnitOfWork _unitOfWork;
    
        public UpdateStockCommandHandler(ILogger<UpdateStockCommandHandler> logger, IInventoryRepository inventoryRepository, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _inventoryRepository = inventoryRepository; 
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateStockCommand request, CancellationToken cancellationToken)
        {
            DomainExceptionValidation.When(request == null || request.StockDto == null, "Updating data is required");
            DomainExceptionValidation.When(request.StockDto.Value < 0, "The value cannot be negative");

            Domain.Entities.Inventory inventory = await _inventoryRepository.GetByIdAsync(request.InventoryId);
            DomainExceptionValidation.When(inventory == null, $"{request.InventoryId}: Inventory item didn't find");

            switch (request.StockDto.Operation)
            {
                case DTOs.Inventory.OperationType.Increase:
                    inventory.IncreaseStock(request.StockDto.Value);
                    break;
                case DTOs.Inventory.OperationType.Decrease:
                    inventory.DecreaseStock(request.StockDto.Value);
                    break;
                default:
                    break;
            }

            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
