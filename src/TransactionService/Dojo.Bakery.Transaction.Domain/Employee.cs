namespace Dojo.Bakery.Transaction.Domain;

public class Employee : AggregateRoot
{
    public string Name { get; set; }
    public string RoleId { get; set; }
    public string DocumentId { get; set; }

    public string Password { get; set; }
}
