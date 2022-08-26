using Dojo.Bakery.Transaction.Application.DTOs.Store;
using Dojo.Bakery.Transaction.Application.Queries.Store;
using Dojo.Bakery.Transaction.Domain;
using Dojo.Bakery.Transaction.Infra.DataContract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dojo.Bakery.Transaction.Application.Handlers.Store
{
    public class GetAllStoreQueryHandler : IRequestHandler<GetAllStoreQuery, List<StoreDto>>
    {
        private readonly ILogger<GetAllStoreQueryHandler> _logger;
        private readonly IStoreRepository _storeRepository;

        public GetAllStoreQueryHandler(ILogger<GetAllStoreQueryHandler> logger, IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
            _logger = logger;
        }
        
        public async Task<List<StoreDto>> Handle(GetAllStoreQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Domain.Store> query = from i in await _storeRepository.GetEntitiesAsync()
                                         orderby i.Name
                                         select i;
            List<StoreDto> list = new List<StoreDto>();
            foreach (Domain.Store item in query.ToList())
            {
                list.Add(new StoreDto()
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }
            return list;
        }
    }
}
