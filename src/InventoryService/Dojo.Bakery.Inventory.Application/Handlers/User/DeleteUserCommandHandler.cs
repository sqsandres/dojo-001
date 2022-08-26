using Dojo.Bakery.Inventory.Application.Commands.User;

namespace Dojo.Bakery.Inventory.Application.Handlers.User
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, MediatR.Unit>
    {
        private readonly ILogger<DeleteUserCommandHandler> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteUserCommandHandler(ILogger<DeleteUserCommandHandler> logger, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<MediatR.Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            DomainExceptionValidation.When(request == null || request.Id == Guid.Empty, "Delete Id data is required");
            Domain.User User = await _userRepository.GetByIdAsync(request.Id);
            DomainExceptionValidation.When(User == null, "User not found");
            await _userRepository.RemoveEntityAsync(User);
            await _unitOfWork.CommitAsync();
            return MediatR.Unit.Value;
        }
    }
}
