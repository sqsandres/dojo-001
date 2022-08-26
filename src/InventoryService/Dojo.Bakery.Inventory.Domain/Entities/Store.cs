using Dojo.Bakery.BuildingBlocks.Commons;

namespace Dojo.Bakery.Inventory.Domain.Entities
{
    public class Store: AggregateRoot
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }

        private Store()
        {

        }

        public Store(string name, string email, string telephone, string address)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), DomainExceptionValidation.RequiredValueMessage, nameof(name));
            DomainExceptionValidation.When(string.IsNullOrEmpty(email), DomainExceptionValidation.RequiredValueMessage, nameof(email));
            DomainExceptionValidation.When(string.IsNullOrEmpty(telephone), DomainExceptionValidation.RequiredValueMessage, nameof(telephone));
            DomainExceptionValidation.When(string.IsNullOrEmpty(address), DomainExceptionValidation.RequiredValueMessage, nameof(address));
            Name = name;
            Email = email;
            Telephone = telephone;  
            Address = address;  
            Id = IdentityGenerator.NewSequentialGuid();
        }
    }
}