namespace Dojo.Bakery.BuildingBlocks.Commons.Repositories
{
    public interface IGetEntity<TEntity> where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetEntitiesAsync();
        Task<TEntity> GetByIdAsync(Guid id);
    }

}
