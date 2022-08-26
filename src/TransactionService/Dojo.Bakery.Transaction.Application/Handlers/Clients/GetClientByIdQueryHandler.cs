namespace Dojo.Bakery.Transaction.Application.Handlers.Clients;

public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, ClientDto>
{
    private readonly ILogger<GetClientByIdQueryHandler> _logger;
    private readonly IClientRepository _clientRepository;

    public GetClientByIdQueryHandler(ILogger<GetClientByIdQueryHandler> logger, IClientRepository clientRepository)
    {
        _logger = logger;
        _clientRepository = clientRepository;
    }

    async Task<ClientDto> IRequestHandler<GetClientByIdQuery, ClientDto>.Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(request.Id.ToString()), "Client Id is required");
        Client query = await _clientRepository.GetByIdAsync(request.Id);
        DomainExceptionValidation.When(query == null, "Client not found");
        ClientDto client = new ClientDto()
        {
            Id = query.Id,
            Name = query.Name,
            Documento = query.DocumentId,
            DocumentTypeId = query.DocumentTypeId,
            Address = query.Address,
            PhoneNumber = query.PhoneNumber,
            Email = query.Email
        };
        return client;
    }
}
