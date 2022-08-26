using Microsoft.EntityFrameworkCore;

namespace Dojo.Bakery.BuildingBlocks.Commons.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitAsync();
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        TContext Context { get; }
    }
}
