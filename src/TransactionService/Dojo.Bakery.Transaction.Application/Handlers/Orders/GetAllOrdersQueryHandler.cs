using Dojo.Bakery.BuildingBlocks.Commons.Repositories;
using Dojo.Bakery.Transaction.Application.DTOs.Orders;
using Dojo.Bakery.Transaction.Application.Queries.Orders;
using Dojo.Bakery.Transaction.Infra.DataContract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dojo.Bakery.Transaction.Application.Handlers.Orders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<OrdersDto>>
    {
        private readonly ILogger<GetAllOrdersQueryHandler> _logger;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public GetAllOrdersQueryHandler(ILogger<GetAllOrdersQueryHandler> logger, IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<List<OrdersDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var query = await _orderRepository.GetEntitiesAsync();
            List<OrdersDto> ordersDto = new List<OrdersDto> ();
            foreach (var item in query.ToList())
            {
                OrdersDto orderDto = new OrdersDto()
                {
                    Id = item.Id,
                    VendorId = item.VendorId,
                    Total = item.Total,
                    InvoiceNumber = item.InvoiceNumber,
                    DeliveryDate = item.DeliveryDate
                };

                var query2 = from d in await _orderDetailRepository.GetEntitiesAsync() select d;
                orderDto.Details = query2.Where(x => x.OrderId == item.Id)
                                    .Select(x => new OrderDetailDto
                                    {
                                        OrderId = x.OrderId,
                                        Total = x.Total,
                                        ProducId = x.ProducId,
                                        Quantity = x.Quantity,
                                        UnitPrice = x.UnitPrice
                                    })
                                    .ToList();
                ordersDto.Add(orderDto);
            }
            return ordersDto;
        }
    }
}
