using Dojo.Bakery.Transaction.Application.DTOs.Sell;
using Dojo.Bakery.Transaction.Application.Queries.Sell;
using Dojo.Bakery.Transaction.Domain;
using Dojo.Bakery.Transaction.Infra.DataContract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dojo.Bakery.Transaction.Application.Handlers.Sell
{
    public class GetAllSellQueryHandler : IRequestHandler<GetAllSellQuery, List<SellDto>>
    {
        private readonly ILogger<GetAllSellQueryHandler> _logger;
        private readonly ISellRepository _sellRepository;

        public GetAllSellQueryHandler(ILogger<GetAllSellQueryHandler> logger, ISellRepository sellRepository)
        {
            _sellRepository = sellRepository;
            _logger = logger;
        }
        
        public async Task<List<SellDto>> Handle(GetAllSellQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Domain.Sell> query = from i in await _sellRepository.GetEntitiesAsync()
                                         orderby i.Name
                                         select i;
            List<SellDto> list = new List<SellDto>();
            foreach (Domain.Sell item in query.ToList())
            {
                list.Add(new SellDto()
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }
            return list;
        }
    }
}
