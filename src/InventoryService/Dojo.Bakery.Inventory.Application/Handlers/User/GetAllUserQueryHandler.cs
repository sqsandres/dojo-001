using Dojo.Bakery.Inventory.Application.DTOs.User;
using Dojo.Bakery.Inventory.Application.Queries.User;
using Dojo.Bakery.Inventory.Infra.DataContract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dojo.Bakery.Inventory.Application.Handlers.User
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<UserDto>>
    {
        private readonly ILogger<GetAllUserQueryHandler> _logger;
        private readonly IUserRepository _userRepository;

        public GetAllUserQueryHandler(ILogger<GetAllUserQueryHandler> logger, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<List<UserDto>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Domain.User> query = from i in await _userRepository.GetEntitiesAsync()
                                             orderby i.Name
                                             select i;
            List<UserDto> list = new List<UserDto>();
            foreach (Domain.User item in query.ToList())
            {
                list.Add(new UserDto()
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }
            return list;
        }
    }
}
