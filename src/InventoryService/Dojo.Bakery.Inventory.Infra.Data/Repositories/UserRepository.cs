using Dojo.Bakery.BuildingBlocks.Commons.Repositories;
using Dojo.Bakery.Inventory.Domain;
using Dojo.Bakery.Inventory.Infra.DataContract;

namespace Dojo.Bakery.Inventory.Infra.Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
