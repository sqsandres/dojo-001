using Dojo.Bakery.Transaction.Application.Commands.Orders;
using Dojo.Bakery.Transaction.Application.DTOs.Orders;
using Dojo.Bakery.Transaction.Application.Queries.Orders;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dojo.Bakery.Transaction.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
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
        public async Task<ActionResult> Create([FromBody] OrdersDto data)
        {
            return Ok(await _mediator.Send(new CreateOrderCommand() { Item = data }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetAllOrdersQuery()));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            return Ok(await _mediator.Send(new GetOrderQuery { OrderId = id }));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            return Ok(await _mediator.Send(new DeleteOrderCommand { OrderId = id }));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] OrdersDto dto)
        {
            return Ok(await _mediator.Send(new UpdateOrderCommand { OrderId = id, Item = dto }));
        }

    }
}
