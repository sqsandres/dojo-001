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
        ValidateDomain(name, number, total, clientId);
        Id = IdentityGenerator.NewSequentialGuid();
    }

    public void Update(string name, string number, decimal total, Guid clientId)
    {
        ValidateDomain(name, number, total, clientId);
    }
    
    private void ValidateDomain(string name, string number, decimal total, Guid clientId)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), DomainExceptionValidation.RequiredValueMessage, nameof(name));
        DomainExceptionValidation.When(string.IsNullOrEmpty(number), DomainExceptionValidation.RequiredValueMessage, nameof(number));
        DomainExceptionValidation.When(total <= 0, DomainExceptionValidation.RequiredValueMessage, nameof(total));
        DomainExceptionValidation.When(clientId == Guid.Empty, DomainExceptionValidation.RequiredValueMessage, nameof(clientId));
        Name = name;
        Number = number;
        ClientId = clientId;
        Total = total;
    }
}
