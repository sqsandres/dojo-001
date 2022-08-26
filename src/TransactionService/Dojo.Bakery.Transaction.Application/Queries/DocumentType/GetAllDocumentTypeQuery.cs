using Dojo.Bakery.Transaction.Application.DTOs.DocumentType;
using MediatR;

namespace Dojo.Bakery.Transaction.Application.Queries.DocumentType
{
    public class GetAllDocumentTypeQuery : IRequest<List<DocumentTypeDto>>
    {
    }
}
