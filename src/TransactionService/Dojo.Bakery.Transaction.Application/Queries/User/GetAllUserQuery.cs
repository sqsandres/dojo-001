using Dojo.Bakery.Transaction.Application.DTOs.User;
using MediatR;

namespace Dojo.Bakery.Transaction.Application.Queries.User
{
    public class GetAllUserQuery : IRequest<List<UserDto>>
    {
    }
}
