using Dojo.Bakery.Transaction.Application.DTOs.DocumentType;
using Dojo.Bakery.Transaction.Application.Queries.DocumentType;
using Dojo.Bakery.Transaction.Domain;
using Dojo.Bakery.Transaction.Infra.DataContract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dojo.Bakery.Transaction.Application.Handlers.DocumentType
{
    public class GetAllDocumentTypeQueryHandler : IRequestHandler<GetAllDocumentTypeQuery, List<DocumentTypeDto>>
    {
        private readonly ILogger<GetAllDocumentTypeQueryHandler> _logger;
        private readonly IDocumentTypeRepository _documentTypeRepository;

        public GetAllDocumentTypeQueryHandler(ILogger<GetAllDocumentTypeQueryHandler> logger, IDocumentTypeRepository documentTypeRepository)
        {
            _documentTypeRepository = documentTypeRepository;
            _logger = logger;
        }
        
        public async Task<List<DocumentTypeDto>> Handle(GetAllDocumentTypeQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Domain.DocumentType> query = from i in await _documentTypeRepository.GetEntitiesAsync()
                                         orderby i.Name
                                         select i;
            List<DocumentTypeDto> list = new List<DocumentTypeDto>();
            foreach (Domain.DocumentType item in query.ToList())
            {
                list.Add(new DocumentTypeDto()
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }
            return list;
        }
    }
}
