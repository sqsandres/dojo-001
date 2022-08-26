using Dojo.Bakery.Inventory.Application.DTOs.User;
using MediatR;

namespace Dojo.Bakery.Inventory.Application.Queries.User
{
    public class GetAllUserQuery : IRequest<List<UserDto>>
    {
    }
}
