using Dojo.Bakery.BuildingBlocks.Commons;
using Dojo.Bakery.BuildingBlocks.Commons.Repositories;
using Dojo.Bakery.Transaction.Application.Commands.Sell;
using Dojo.Bakery.Transaction.Infra.DataContract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dojo.Bakery.Transaction.Application.Handlers.Sell
{
    public class CreateSellCommandHandler : IRequestHandler<CreateSellCommand, Guid>
    {
        private readonly ILogger<CreateSellCommandHandler> _logger;
        private readonly ISellRepository _SellRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateSellCommandHandler(ILogger<CreateSellCommandHandler> logger, ISellRepository SellRepository, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _SellRepository = SellRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateSellCommand request, CancellationToken cancellationToken)
        {
            DomainExceptionValidation.When(request == null || request.Item == null, "Creation data is required");
            Domain.Sell Sell = new Domain.Sell(request.Item.Name, request.Item.Number, request.Item.Total, request.Item.ClientId);
            await _SellRepository.CreateAsync(Sell);
            await _unitOfWork.CommitAsync();
            return Sell.Id;
        }
    }
}
