namespace Dojo.Bakery.Transaction.Application.Handlers.Clients;

public class RemoveClientCommandHandler : IRequestHandler<RemoveClientCommand, Guid>
{
    private readonly ILogger<CreateClientCommandHandler> _logger;
    private readonly IClientRepository _clientRepository;
    private readonly IUnitOfWork _unitOfWork;

    public async Task<Guid> Handle(RemoveClientCommand request, CancellationToken cancellationToken)
    {
        DomainExceptionValidation.When(request == null || request.Id == null, "Client data is required");
        Client client = await _clientRepository.GetByIdAsync(request.Id);
        DomainExceptionValidation.When(client == null, "Client not found");
        await _clientRepository.RemoveEntityAsync(request.Id);
        await _unitOfWork.CommitAsync();
        return request.Id;
    }
}
