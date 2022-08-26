namespace Dojo.Bakery.Inventory.Infra.Data.Repositories;

public class BrandRepository : GenericRepository<Brand>, IBrandRepository
{
    public BrandRepository(ApplicationDbContext context) : base(context)
    {
    }
}
