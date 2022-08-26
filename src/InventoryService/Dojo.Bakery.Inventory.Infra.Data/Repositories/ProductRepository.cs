using Dojo.Bakery.BuildingBlocks.Commons.Repositories;
using Dojo.Bakery.Inventory.Domain.Entities;
using Dojo.Bakery.Inventory.Infra.DataContract;

namespace Dojo.Bakery.Inventory.Infra.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
