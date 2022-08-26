using Dojo.Bakery.BuildingBlocks.Commons;
using Dojo.Bakery.BuildingBlocks.Commons.Repositories;
using Dojo.Bakery.Transaction.Application.Commands.User;
using Dojo.Bakery.Transaction.Infra.DataContract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dojo.Bakery.Transaction.Application.Handlers.User
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Guid>
    {
        private readonly ILogger<UpdateUserCommandHandler> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateUserCommandHandler(ILogger<UpdateUserCommandHandler> logger, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            DomainExceptionValidation.When(request == null || request.Item == null, "Update data is required");
            Domain.User user = await _userRepository.GetByIdAsync(request.Item.Id);
            DomainExceptionValidation.When(user == null, "User not found");
            user.ChangeName(user.Name);
            await _userRepository.UpdateAsync(user);
            await _unitOfWork.CommitAsync();
            return user.Id;
        }
    }
}
