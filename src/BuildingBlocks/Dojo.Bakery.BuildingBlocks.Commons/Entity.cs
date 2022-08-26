namespace Dojo.Bakery.BuildingBlocks.Commons
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        public bool IsActive { get; protected set; }
        public DateTime CreatedOn { get; protected set; }
        public DateTime? UpdatedOn { get; protected set; }
        public Entity()
        {
            IsActive = true;
        }
        public virtual void CreateEntity()
        {
            CreatedOn = DateTime.Now;
        }
        public virtual void UpdateEntity()
        {
            UpdatedOn = DateTime.Now;
        }
    }
}
