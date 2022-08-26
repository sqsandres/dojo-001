using Dojo.Bakery.BuildingBlocks.Commons.Repositories;
using Dojo.Bakery.Inventory.Domain;
using Dojo.Bakery.Inventory.Infra.DataContract;

namespace Dojo.Bakery.Inventory.Infra.Data.Repositories
{
    public class DocumentTypeRepository : GenericRepository<DocumentType>, IDocumentTypeRepository
    {
        public DocumentTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
