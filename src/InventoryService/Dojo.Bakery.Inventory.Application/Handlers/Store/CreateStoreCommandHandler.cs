using Dojo.Bakery.BuildingBlocks.Commons;
using Dojo.Bakery.BuildingBlocks.Commons.Repositories;
using Dojo.Bakery.BuildingBlocks.EventBus;
using Dojo.Bakery.Inventory.Application.Commands.Store;
using Dojo.Bakery.Inventory.Application.Jobs;
using Dojo.Bakery.Inventory.Domain;
using Dojo.Bakery.Inventory.Infra.DataContract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dojo.Bakery.Inventory.Application.Handlers.Store
{
    public class CreateStoreCommandHandler : IRequestHandler<CreateStoreCommand, Guid>
    {
        private readonly ILogger<CreateStoreCommandHandler> _logger;
        private readonly IStoreRepository _storeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly EventBusServiceBus _eventBusServiceBus;
        public CreateStoreCommandHandler(ILogger<CreateStoreCommandHandler> logger, IStoreRepository storeRepository, IUnitOfWork unitOfWork, EventBusServiceBus eventBusServiceBus)
        {
            _logger = logger;
            _storeRepository = storeRepository;
            _unitOfWork = unitOfWork;
            _eventBusServiceBus = eventBusServiceBus;
        }
        public async Task<Guid> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
        {
            DomainExceptionValidation.When(request == null || request.Item == null, "Creation data is required");
            Domain.Store store = new Domain.Store(request.Item.Id, request.Item.Name, request.Item.DocumentNumber);
            await _storeRepository.CreateAsync(store);
            await _unitOfWork.CommitAsync();
            _eventBusServiceBus.Publish(new StoreCreationJob() { Id = request.Item.Id, Name = request.Item.Name });
            return store.Id;
        }
    }
}
