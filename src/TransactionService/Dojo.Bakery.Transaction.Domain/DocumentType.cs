using Dojo.Bakery.BuildingBlocks.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo.Bakery.Transaction.Domain
{
    public class DocumentType : AggregateRoot
    {
        public string Name { get; private set; }
        private DocumentType() { }
        public DocumentType(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), DomainExceptionValidation.RequiredValueMessage, nameof(name));
            Name = name;
            Id = IdentityGenerator.NewSequentialGuid();
        }

        public void ChangeName(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), DomainExceptionValidation.RequiredValueMessage, nameof(name));
            Name = name;
        }
    }
}
