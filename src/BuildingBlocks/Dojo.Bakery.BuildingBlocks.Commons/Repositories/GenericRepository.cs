using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Dojo.Bakery.BuildingBlocks.Commons.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;
        public DbSet<TEntity> GetDbSet()
        {
            return _dbSet;
        }

        protected GenericRepository(DbContext context)
        {
            _dbContext = context ?? throw new ArgumentException(nameof(context));
            _dbSet = _dbContext.Set<TEntity>();
        }
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = await _dbSet.AddAsync(entity);
            return entityEntry.Entity;
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            TEntity entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                entity = _dbSet.Local.FirstOrDefault(x => x.Id == id);
            }
            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetEntitiesAsync()
        {
            IEnumerable<TEntity> query = _dbSet;
            return query;
        }

        public async Task<TEntity> RemoveEntityAsync(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = _dbSet.Remove(entity);
            return entityEntry.Entity;
        }

        public async Task<TEntity> RemoveEntityAsync(Guid id)
        {
            TEntity entity = await _dbSet.FindAsync(id);
            EntityEntry<TEntity> entityEntry = _dbSet.Remove(entity);
            return entityEntry.Entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = _dbSet.Update(entity);
            return entityEntry.Entity;
        }
    }

}
