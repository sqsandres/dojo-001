namespace Dojo.Bakery.BuildingBlocks.Commons.Repositories
{
    public interface IDeleteEntity<TEntity> where TEntity : Entity
    {
        Task<TEntity> RemoveEntityAsync(TEntity entity);
        Task<TEntity> RemoveEntityAsync(Guid id);
    }

}
