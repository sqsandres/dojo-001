using Dojo.Bakery.BuildingBlocks.Commons.Repositories;
using Dojo.Bakery.Transaction.Domain;
using Dojo.Bakery.Transaction.Infra.DataContract;

namespace Dojo.Bakery.Transaction.Infra.Data.Repositories
{
    public class DocumentTypeRepository : GenericRepository<DocumentType>, IDocumentTypeRepository
    {
        public DocumentTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
