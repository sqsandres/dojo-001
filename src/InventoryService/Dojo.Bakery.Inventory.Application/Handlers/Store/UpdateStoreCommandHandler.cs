using Dojo.Bakery.BuildingBlocks.Commons;
using Dojo.Bakery.BuildingBlocks.Commons.Repositories;
using Dojo.Bakery.Inventory.Application.Commands.Store;
using Dojo.Bakery.Inventory.Infra.DataContract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dojo.Bakery.Inventory.Application.Handlers.Store
{
    public class UpdateStoreCommandHandler : IRequestHandler<UpdateStoreCommand, Guid>
    {
        private readonly ILogger<UpdateStoreCommandHandler> _logger;
        private readonly IStoreRepository _storeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateStoreCommandHandler(ILogger<UpdateStoreCommandHandler> logger, IStoreRepository storeRepository, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _storeRepository = storeRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
        {
            DomainExceptionValidation.When(request == null || request.Item == null, "Update data is required");
            Domain.Store store = await _storeRepository.GetByIdAsync(request.Item.Id);
            DomainExceptionValidation.When(store == null, "Store not found");
            store.ChangeName(store.Name);
            await _storeRepository.UpdateAsync(store);
            await _unitOfWork.CommitAsync();
            return store.Id;
        }
    }
}
