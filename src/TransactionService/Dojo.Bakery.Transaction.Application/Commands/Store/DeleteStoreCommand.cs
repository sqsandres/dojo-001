namespace Dojo.Bakery.Transaction.Application.Commands.Store
{
    public class DeleteStoreCommand : IRequest<MediatR.Unit>
    {
        public Guid Id { get; set; }
    }
}
