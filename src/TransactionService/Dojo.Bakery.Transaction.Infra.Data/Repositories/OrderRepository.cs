using Dojo.Bakery.BuildingBlocks.Commons.Repositories;
using Dojo.Bakery.Transaction.Domain;
using Dojo.Bakery.Transaction.Infra.DataContract;

namespace Dojo.Bakery.Transaction.Infra.Data.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
