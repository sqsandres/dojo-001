using Dojo.Bakery.BuildingBlocks.Commons;
using Dojo.Bakery.BuildingBlocks.Commons.Repositories;
using Dojo.Bakery.Transaction.Application.DTOs.Orders;
using Dojo.Bakery.Transaction.Application.Queries.Orders;
using Dojo.Bakery.Transaction.Infra.DataContract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dojo.Bakery.Transaction.Application.Handlers.Orders
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrdersDto>
    {
        private readonly ILogger<GetOrderQueryHandler> _logger;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public GetOrderQueryHandler(ILogger<GetOrderQueryHandler> logger, IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }
        public async Task<OrdersDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var query = await _orderRepository.GetByIdAsync(request.OrderId);
            DomainExceptionValidation.When(query == null, $"{request.OrderId}: Order didn't find");

            OrdersDto ordersDto = new OrdersDto()
            {
                Id = query.Id,
                VendorId = query.VendorId,
                Total = query.Total,
                InvoiceNumber = query.InvoiceNumber,
                DeliveryDate = query.DeliveryDate
            };

            var query2 = from d in await _orderDetailRepository.GetEntitiesAsync()
                                select d;
            ordersDto.Details = query2.Where(x => x.OrderId == request.OrderId)
                                .Select(x => new OrderDetailDto
                                {
                                    OrderId = x.OrderId,
                                    Total = x.Total,
                                    ProducId = x.ProducId,
                                    Quantity = x.Quantity,
                                    UnitPrice = x.UnitPrice
                                })
                                .ToList();

            return ordersDto;
        }
    }
}
