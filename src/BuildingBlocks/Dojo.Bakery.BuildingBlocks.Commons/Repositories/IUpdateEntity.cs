namespace Dojo.Bakery.BuildingBlocks.Commons.Repositories
{
    public interface IUpdateEntity<TEntity> where TEntity : Entity
    {
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
