using Dojo.Bakery.BuildingBlocks.Commons;
using Dojo.Bakery.BuildingBlocks.Commons.Repositories;
using Dojo.Bakery.Inventory.Application.Commands.Inventory;
using Dojo.Bakery.Inventory.Infra.DataContract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dojo.Bakery.Inventory.Application.Handlers.Inventory
{
    public class DeleteInventoryItemCommandHandler : IRequestHandler<DeleteInventoryItemCommand, Guid>
    {
        private readonly ILogger<DeleteInventoryItemCommandHandler> _logger;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteInventoryItemCommandHandler(ILogger<DeleteInventoryItemCommandHandler> logger, IInventoryRepository inventoryRepository, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _inventoryRepository = inventoryRepository; 
            _unitOfWork = unitOfWork;   
        }

        public async Task<Guid> Handle(DeleteInventoryItemCommand request, CancellationToken cancellationToken)
        {
            DomainExceptionValidation.When(request == null || request.InventoryId == Guid.Empty, "The inventory Id is required");
            await _inventoryRepository.RemoveEntityAsync(request.InventoryId);
            await _unitOfWork.CommitAsync();
            return Guid.Empty;
        }
    }
}
