
namespace Dojo.Bakery.Transaction.Application.Handlers.Clients;

public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, List<ClientDto>>
{
    private readonly ILogger<UpdateClientCommandHandler> _logger;
    private readonly IClientRepository _clientRepository;

    public GetAllClientsQueryHandler(ILogger<UpdateClientCommandHandler> logger, IClientRepository clientRepository)
    {
        _logger = logger;
        _clientRepository = clientRepository;
    }

    public async Task<List<ClientDto>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Client> query = from cl in await _clientRepository.GetEntitiesAsync()
                                       orderby cl.Id
                                       select cl;
        DomainExceptionValidation.When(query == null, "There is not clients");
        List<ClientDto> client = new List<ClientDto>();
        foreach (Client item in query)
        {
            client.Add(new ClientDto()
            {
                Id = item.Id,
                Name = item.Name,
                Documento = item.Documento,
                DocumentTypeId = item.DocumentTypeId,
                Address = item.Address,
                PhoneNumber = item.PhoneNumber,
                Email = item.Email
            });
        }
        return client;
    }
}
