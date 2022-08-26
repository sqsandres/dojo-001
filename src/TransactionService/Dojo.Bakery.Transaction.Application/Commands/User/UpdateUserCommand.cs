using Dojo.Bakery.Transaction.Application.DTOs.User;
using MediatR;

namespace Dojo.Bakery.Transaction.Application.Commands.User
{
    public class UpdateUserCommand : IRequest<Guid>
    {
        public UserDto Item { get; set; }
    }
}
