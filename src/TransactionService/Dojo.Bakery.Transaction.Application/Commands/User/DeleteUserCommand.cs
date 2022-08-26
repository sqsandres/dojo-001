namespace Dojo.Bakery.Transaction.Application.Commands.User
{
    public class DeleteUserCommand : IRequest<MediatR.Unit>
    {
        public Guid Id { get; set; }
    }
}
