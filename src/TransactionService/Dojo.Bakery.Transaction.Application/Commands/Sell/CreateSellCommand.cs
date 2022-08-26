using Dojo.Bakery.Transaction.Application.DTOs.Sell;
using MediatR;

namespace Dojo.Bakery.Transaction.Application.Commands.Sell
{
    public class CreateSellCommand : IRequest<Guid>
    {
        public SellDto Item { get; set; }
    }
}
