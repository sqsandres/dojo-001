using Dojo.Bakery.BuildingBlocks.Commons;

namespace Dojo.Bakery.Inventory.Domain.Entities
{
    public class Category: AggregateRoot
    {
        public string Name { get; private set; }

        private Category() { }

        public Category(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), DomainExceptionValidation.RequiredValueMessage, nameof(name));
            Name = name;
            Id = IdentityGenerator.NewSequentialGuid();
        }
    }
}