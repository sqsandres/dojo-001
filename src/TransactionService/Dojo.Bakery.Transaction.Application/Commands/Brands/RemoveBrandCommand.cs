namespace Dojo.Bakery.Transaction.Application.Commands.Brands;

public class RemoveBrandCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
}
