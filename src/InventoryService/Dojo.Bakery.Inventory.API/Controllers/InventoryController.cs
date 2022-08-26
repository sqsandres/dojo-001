using Dojo.Bakery.BuildingBlocks.WebCommons;
using Dojo.Bakery.BuildingBlocks.WebCommons.Models;
using Dojo.Bakery.Inventory.Application.Commands.Inventory;
using Dojo.Bakery.Inventory.Application.DTOs.Inventory;
using Dojo.Bakery.Inventory.Application.Queries.Inventory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dojo.Bakery.Inventory.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : BaseController
    {
        private readonly IMediator _mediator;

        public InventoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<Response>> Create([FromBody] InventoryDto data)
        {
            return Result(await _mediator.Send(new CreateInventoryItemCommand() { Item = data }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<ActionResult<Response>> Get()
        {
            return Result(await _mediator.Send(new GetAllInventoryQuery()));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetById(Guid id)
        {
            return Result(await _mediator.Send(new GetInventoryItemQuery { InventoryId = id }));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> Delete(Guid id)
        {
            return Result(await _mediator.Send(new DeleteInventoryItemCommand { InventoryId = id }));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> Update(Guid id, [FromBody] InventoryDto dto)
        {
            return Result(await _mediator.Send(new UpdateInventoryItemCommand { InventoryId = id, Item = dto }));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}/stock")]
        public async Task<ActionResult<Response>> UpdateStock(Guid id, [FromBody] StockDto dto)
        {
            return Result(await _mediator.Send(new UpdateStockCommand { InventoryId = id, StockDto = dto }));
        }

    }
}
