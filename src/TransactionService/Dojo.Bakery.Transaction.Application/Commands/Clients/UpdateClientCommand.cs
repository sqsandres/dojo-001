using Dojo.Bakery.Transaction.Application.DTOs.Clients;

namespace Dojo.Bakery.Transaction.Application.Commands.Clients;

public class UpdateClientCommand : IRequest<Guid>
{
    public ClientDto Item { get; set; }
}
