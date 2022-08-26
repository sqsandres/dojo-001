using Dojo.Bakery.BuildingBlocks.Commons.Repositories;
using Dojo.Bakery.Transaction.Domain;
using Dojo.Bakery.Transaction.Infra.DataContract;

namespace Dojo.Bakery.Transaction.Infra.Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
