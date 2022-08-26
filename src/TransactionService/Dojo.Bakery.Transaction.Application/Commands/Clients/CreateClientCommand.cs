
namespace Dojo.Bakery.Transaction.Application.Commands.Clients;

public class CreateClientCommand : IRequest<Guid>
{
    public ClientDto Item { get; set; }
}
