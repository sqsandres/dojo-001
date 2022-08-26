
namespace Dojo.Bakery.Transaction.Application.Commands.Clients;

public class RemoveClientCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
}
