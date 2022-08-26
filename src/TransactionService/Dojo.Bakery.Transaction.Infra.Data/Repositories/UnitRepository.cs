namespace Dojo.Bakery.Transaction.Infra.Data.Repositories;

public class UnitRepository : GenericRepository<Unit>, IUnitRepository
{
    public UnitRepository(ApplicationDbContext context) : base(context)
    {
    }
}
