using Dojo.Bakery.BuildingBlocks.Commons.Repositories;
using Dojo.Bakery.Transaction.Application.Commands.Orders;
using Dojo.Bakery.Transaction.Infra.DataContract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dojo.Bakery.Transaction.Application.Handlers.Orders
{
    internal class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Guid>
    {
        private readonly ILogger<DeleteOrderCommandHandler> _logger;
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public DeleteOrderCommandHandler(ILogger<DeleteOrderCommandHandler> logger, IOrderRepository orderRepository, IUnitOfWork unitOfWork, IOrderDetailRepository orderDetailRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository; 
            _unitOfWork = unitOfWork;   
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<Guid> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            await _orderRepository.RemoveEntityAsync(request.OrderId);
            foreach (var item in (await _orderDetailRepository.GetEntitiesAsync()).Where(x => x.OrderId == request.OrderId))
            {
                await _orderDetailRepository.RemoveEntityAsync(item.Id);
            }
            await _unitOfWork.CommitAsync();
            return Guid.Empty;
        }
    }
}
