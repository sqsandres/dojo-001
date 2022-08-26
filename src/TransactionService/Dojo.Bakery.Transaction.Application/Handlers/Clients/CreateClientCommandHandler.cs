

namespace Dojo.Bakery.Transaction.Application.Handlers.Clients;

public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Guid>
{
    private readonly ILogger<CreateClientCommandHandler> _logger;
    private readonly IClientRepository _clientRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateClientCommandHandler(ILogger<CreateClientCommandHandler> logger, IClientRepository clientRepository, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _clientRepository = clientRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        DomainExceptionValidation.When(request == null || request.Item == null, "Creation data is required");

        Client client = new(
            request.Item.Name,
            request.Item.Documento,
            request.Item.DocumentTypeId,
            request.Item.Address,
            request.Item.PhoneNumber,
            request.Item.Email
            );
        await _clientRepository.CreateAsync(client);
        await _unitOfWork.CommitAsync();
        return client.Id;
    }
}
