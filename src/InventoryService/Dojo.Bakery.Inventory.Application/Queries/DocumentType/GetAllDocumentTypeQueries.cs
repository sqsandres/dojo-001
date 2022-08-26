using Dojo.Bakery.Inventory.Application.DTOs.DocumentType;
using MediatR;

namespace Dojo.Bakery.Inventory.Application.Queries.DocumentType
{
    public class GetAllDocumentTypeQuery : IRequest<List<DocumentTypeDto>>
    {
    }
}
