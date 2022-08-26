using Dojo.Bakery.BuildingBlocks.Commons;
using Dojo.Bakery.BuildingBlocks.Commons.Repositories;
using Dojo.Bakery.Transaction.Application.Commands.Orders;
using Dojo.Bakery.Transaction.Infra.DataContract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dojo.Bakery.Transaction.Application.Handlers.Orders
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Guid>
    {
        private readonly ILogger<UpdateOrderCommandHandler> _logger;
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public UpdateOrderCommandHandler(ILogger<UpdateOrderCommandHandler> logger, IOrderRepository orderRepository, IUnitOfWork unitOfWork, IOrderDetailRepository orderDetailRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<Guid> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            DomainExceptionValidation.When(request == null, "The order Id and inventory data are required");
            DomainExceptionValidation.When(request.OrderId == Guid.Empty, "The order Id is required");
            DomainExceptionValidation.When(request.Item == null, "The order data is required");

            var order = await _orderRepository.GetByIdAsync(request.OrderId);
            DomainExceptionValidation.When(order == null, $"{request.OrderId}: Order didn't find");

            order.Updated(request.Item.VendorId, request.Item.Total, request.Item.InvoiceNumber, request.Item.DeliveryDate);
            await _unitOfWork.CommitAsync();

            return request.OrderId;
        }
    }
}
