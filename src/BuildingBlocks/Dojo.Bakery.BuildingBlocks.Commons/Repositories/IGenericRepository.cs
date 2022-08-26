namespace Dojo.Bakery.BuildingBlocks.Commons.Repositories
{
    public interface IGenericRepository<TEntity> : IGetEntity<TEntity>, ICreateEntity<TEntity>,
            IUpdateEntity<TEntity>, IDeleteEntity<TEntity> where TEntity : Entity
    {
    }
}
