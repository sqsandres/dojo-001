using Dojo.Bakery.Inventory.Application.DTOs.Inventory;
using MediatR;

namespace Dojo.Bakery.Inventory.Application.Queries.Inventory
{
    public class GetAllInventoryQuery: IRequest<List<InventoryResponseDto>>
    {
    }
}
