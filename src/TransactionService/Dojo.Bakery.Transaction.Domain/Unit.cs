namespace Dojo.Bakery.Transaction.Domain;

public class Unit : AggregateRoot
{
    public string Name { get; set; }

    private Unit() { }
    public Unit(string name)
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
