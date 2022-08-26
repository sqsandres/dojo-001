namespace Dojo.Bakery.Transaction.Application.Queries.Clients;

public class GetClientByIdQuery : IRequest<ClientDto>
{
    public Guid Id { get; set; }
}
