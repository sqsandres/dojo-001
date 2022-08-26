
namespace Dojo.Bakery.Transaction.Infra.Data.Repositories;

public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
{
    public SupplierRepository(ApplicationDbContext context) : base(context)
    {
    }
}
