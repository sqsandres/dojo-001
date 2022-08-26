using Dojo.Bakery.BuildingBlocks.Commons.Repositories;
using Dojo.Bakery.Inventory.Infra.DataContract;
using Microsoft.EntityFrameworkCore;

namespace Dojo.Bakery.Inventory.Infra.Data.Repositories
{
    public class InventoryRepository : GenericRepository<Domain.Entities.Inventory>, IInventoryRepository
    {
        public InventoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
