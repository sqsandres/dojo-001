namespace Dojo.Bakery.Transaction.Infra.Data.Repositories;

public class ClientRepository : GenericRepository<Client>, IClientRepository
{
    public ClientRepository(ApplicationDbContext context) : base(context)
    {
    }
}
