using Dojo.Bakery.BuildingBlocks.Commons;

namespace Dojo.Bakery.Inventory.Domain
{
    public class Store : AggregateRoot
    {
        public string Name { get; private set; }
        public string DocumentNumber { get; private set; }
        private Store() { }
        public Store(Guid id, string name, string documentNumber)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), DomainExceptionValidation.RequiredValueMessage, nameof(name));
            DomainExceptionValidation.When(string.IsNullOrEmpty(documentNumber), DomainExceptionValidation.RequiredValueMessage, nameof(documentNumber));
            DomainExceptionValidation.When(id==Guid.Empty, DomainExceptionValidation.RequiredValueMessage, nameof(id));
            Id = id;
            Name = name;
            DocumentNumber = documentNumber;
            Id = IdentityGenerator.NewSequentialGuid();
        }
        public void ChangeName(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), DomainExceptionValidation.RequiredValueMessage, nameof(name));
            Name = name;
        }
        public void ChangeDocumentNumber(string documentNumber)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(documentNumber), DomainExceptionValidation.RequiredValueMessage, nameof(documentNumber));
            DocumentNumber = documentNumber;
        }
    }
}
