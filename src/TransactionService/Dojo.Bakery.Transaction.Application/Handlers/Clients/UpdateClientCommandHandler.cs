namespace Dojo.Bakery.Transaction.Application.Handlers.Clients;

public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Guid>
{
    private readonly ILogger<UpdateClientCommandHandler> _logger;
    private readonly IClientRepository _clientRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateClientCommandHandler(ILogger<UpdateClientCommandHandler> logger, IClientRepository clientRepository, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _clientRepository = clientRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        DomainExceptionValidation.When(request == null || request.Item == null, "Update data is required");

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
