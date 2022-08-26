using Dojo.Bakery.BuildingBlocks.Commons;

namespace Dojo.Bakery.Inventory.Domain
{
    public class User : AggregateRoot
    {
        public string Name { get; private set; }
        private User() { }
        public User(Guid id, string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), DomainExceptionValidation.RequiredValueMessage, nameof(name));
            DomainExceptionValidation.When(id == Guid.Empty, DomainExceptionValidation.RequiredValueMessage, nameof(id));
            Name = name;
            Id = id;
        }

        public void ChangeName(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), DomainExceptionValidation.RequiredValueMessage, nameof(name));
            Name = name;
        }
    }
}
