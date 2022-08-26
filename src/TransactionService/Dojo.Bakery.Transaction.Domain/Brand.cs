namespace Dojo.Bakery.Transaction.Domain;

public class Brand : AggregateRoot
{
    public string Name { get; private set; }

    private Brand() { }
    public Brand(string name)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), DomainExceptionValidation.RequiredValueMessage, nameof(name));
        Name = name;
        Id = IdentityGenerator.NewSequentialGuid();
    }
}
