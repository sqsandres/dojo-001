using Dojo.Bakery.BuildingBlocks.Commons;
using Dojo.Bakery.BuildingBlocks.Commons.Repositories;
using Dojo.Bakery.Transaction.Application.Commands.Store;
using Dojo.Bakery.Transaction.Infra.DataContract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dojo.Bakery.Transaction.Application.Handlers.Store
{
    public class CreateStoreCommandHandler : IRequestHandler<CreateStoreCommand, Guid>
    {
        private readonly ILogger<CreateStoreCommandHandler> _logger;
        private readonly IStoreRepository _storeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateStoreCommandHandler(ILogger<CreateStoreCommandHandler> logger, IStoreRepository storeRepository, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _storeRepository = storeRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
        {
            DomainExceptionValidation.When(request == null || request.Item == null, "Creation data is required");
            Domain.Store store = new Domain.Store(request.Item.Name, request.Item.Address, request.Item.Phone, request.Item.City, request.Item.Email, request.Item.Country, request.Item.DocumentNumber, request.Item.OpenTime, request.Item.CloseTime);
            await _storeRepository.CreateAsync(store);
            await _unitOfWork.CommitAsync();
            return store.Id;
        }
    }
}
