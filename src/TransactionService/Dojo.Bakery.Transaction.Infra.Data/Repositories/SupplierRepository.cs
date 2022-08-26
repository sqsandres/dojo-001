
namespace Dojo.Bakery.Transaction.Infra.Data.Repositories;

public class SupplierRepository : GenericRepository<Client>, ISupplierRepository
{
    public SupplierRepository(ApplicationDbContext context) : base(context)
    {
    }
}
