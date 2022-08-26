using Dojo.Bakery.BuildingBlocks.Commons;
using Dojo.Bakery.BuildingBlocks.Commons.ModelContracts;
using Microsoft.AspNetCore.Identity;

namespace Dojo.Bakery.Security.Domain
{
    public class ApplicationUser : IdentityUser<Guid>, IAggregateRoot
    {
        private ApplicationUser()
        {
        }
        public ApplicationUser(string userName, string name, string lastName, string email, Guid tenantId)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(userName), DomainExceptionValidation.RequiredValueMessage, nameof(userName));
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), DomainExceptionValidation.RequiredValueMessage, nameof(userName));
            DomainExceptionValidation.When(string.IsNullOrEmpty(lastName), DomainExceptionValidation.RequiredValueMessage, nameof(userName));
            DomainExceptionValidation.When(string.IsNullOrEmpty(email), DomainExceptionValidation.RequiredValueMessage, nameof(userName));

            Id = IdentityGenerator.NewSequentialGuid();
            UserName = userName;
            LastName = lastName;
            Name = name;
            Email = email;
            UpdatedOn = DateTime.Now;
            CreatedOn = DateTime.Now;
            IsActive = true;
        }
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; protected set; }
        public DateTime CreatedOn { get; protected set; }
        public DateTime UpdatedOn { get; protected set; }
        public Guid TenantId { get; set; }
        public virtual void Deactivate()
        {
            IsActive = false;
            UpdatedOn = DateTime.Now;
        }
        public virtual void Activate()
        {
            IsActive = true;
            UpdatedOn = DateTime.Now;
        }
        private readonly List<IEvent> _domainEvents = new List<IEvent>();
        public virtual IReadOnlyList<IEvent> DomainEvents => _domainEvents;
        protected virtual void AddDomainEvent(IEvent newEvent)
        {
            _domainEvents.Add(newEvent);
        }
        public virtual void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}