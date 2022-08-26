using Dojo.Bakery.Transaction.Application.DTOs.User;
using MediatR;

namespace Dojo.Bakery.Transaction.Application.Commands.User
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public UserDto Item { get; set; }
    }
}
