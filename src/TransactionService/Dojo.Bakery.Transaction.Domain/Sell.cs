using Dojo.Bakery.BuildingBlocks.Commons;

namespace Dojo.Bakery.Transaction.Domain;

public class Sell : AggregateRoot
{
    public string Name { get; private set; }
    public string Number { get; private set; }
    public decimal Total { get; private set; }
    public Guid ClientId { get; private set; }
    private Sell() { }
    public Sell(string name, string number, decimal total, Guid clientId)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), DomainExceptionValidation.RequiredValueMessage,nameof(name));
        DomainExceptionValidation.When(string.IsNullOrEmpty(number), DomainExceptionValidation.RequiredValueMessage,nameof(number));
        DomainExceptionValidation.When(total <= 0, DomainExceptionValidation.RequiredValueMessage,nameof(total));
        DomainExceptionValidation.When(ClientId == Guid.Empty, DomainExceptionValidation.RequiredValueMessage,nameof(clientId));
        Name = name;
        Number = number;
        ClientId = clientId;
        Total = total;
        Id = IdentityGenerator.NewSequentialGuid();
    }
}
