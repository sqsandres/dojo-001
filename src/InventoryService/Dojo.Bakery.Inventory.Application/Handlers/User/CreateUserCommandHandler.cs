using Dojo.Bakery.BuildingBlocks.Commons;
using Dojo.Bakery.BuildingBlocks.Commons.Repositories;
using Dojo.Bakery.Inventory.Application.Commands.User;
using Dojo.Bakery.Inventory.Infra.DataContract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dojo.Bakery.Inventory.Application.Handlers.User
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly ILogger<CreateUserCommandHandler> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserCommandHandler(ILogger<CreateUserCommandHandler> logger, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            DomainExceptionValidation.When(request == null || request.Item == null, "Creation data is required");
            Domain.User user = new Domain.User(request.Item.Id, request.Item.Name);
            await _userRepository.CreateAsync(user);
            await _unitOfWork.CommitAsync();
            return user.Id;
        }
    }
}
