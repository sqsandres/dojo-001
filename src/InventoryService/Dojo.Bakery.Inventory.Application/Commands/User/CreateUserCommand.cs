using Dojo.Bakery.Inventory.Application.DTOs.User;
using MediatR;

namespace Dojo.Bakery.Inventory.Application.Commands.User
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public UserDto Item { get; set; }
    }
}
