

namespace Dojo.Bakery.Transaction.Application.Handlers.Store
{
    public class DeleteStoreCommandHandler : IRequestHandler<DeleteStoreCommand, MediatR.Unit>
    {
        private readonly ILogger<DeleteStoreCommandHandler> _logger;
        private readonly IStoreRepository _storeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteStoreCommandHandler(ILogger<DeleteStoreCommandHandler> logger, IStoreRepository storeRepository, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _storeRepository = storeRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<MediatR.Unit> Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
        {
            DomainExceptionValidation.When(request == null || request.Id == Guid.Empty, "Delete Id data is required");
            Domain.Store store = await _storeRepository.GetByIdAsync(request.Id);
            DomainExceptionValidation.When(store == null, "Store not found");
            await _storeRepository.RemoveEntityAsync(store);
            await _unitOfWork.CommitAsync();
            return MediatR.Unit.Value;
        }
    }
}
