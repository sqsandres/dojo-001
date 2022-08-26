using Dojo.Bakery.BuildingBlocks.Commons;
using Dojo.Bakery.BuildingBlocks.Commons.Repositories;
using Dojo.Bakery.Transaction.Application.Commands.Orders;
using Dojo.Bakery.Transaction.Infra.DataContract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dojo.Bakery.Transaction.Application.Handlers.Orders
{
    internal class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly ILogger<CreateOrderCommandHandler> _logger;
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public CreateOrderCommandHandler(ILogger<CreateOrderCommandHandler> logger, IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _orderRepository = orderRepository; 
            _orderDetailRepository = orderDetailRepository;
            _unitOfWork = unitOfWork;   
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            DomainExceptionValidation.When(request == null || request.Item == null, "Creation data is required");
            Domain.Order order = new Domain.Order(request.Item.VendorId, request.Item.Total, request.Item.InvoiceNumber, request.Item.DeliveryDate);
            await _orderRepository.CreateAsync(order);
            await _unitOfWork.CommitAsync();

            foreach (var x in request.Item.Details)
            {
                var orderDetail = new Domain.OrderDetail(order.Id,x.ProducId,x.Quantity,x.UnitPrice);
                await _orderDetailRepository.CreateAsync(orderDetail);
            }
            await _unitOfWork.CommitAsync();

            return order.Id;
        }
    }
}
