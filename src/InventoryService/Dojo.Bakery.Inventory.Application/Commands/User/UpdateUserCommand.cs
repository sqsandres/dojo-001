using Dojo.Bakery.Inventory.Application.DTOs.User;
using MediatR;

namespace Dojo.Bakery.Inventory.Application.Commands.User
{
    public class UpdateUserCommand : IRequest<Guid>
    {
        public UserDto Item { get; set; }
    }
}
