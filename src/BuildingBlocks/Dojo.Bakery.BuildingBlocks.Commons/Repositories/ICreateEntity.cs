namespace Dojo.Bakery.BuildingBlocks.Commons.Repositories
{
    public interface ICreateEntity<TEntity> where TEntity : Entity
    {
        Task<TEntity> CreateAsync(TEntity entity);
    }
}
