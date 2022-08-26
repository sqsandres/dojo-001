using Dojo.Bakery.Transaction.Application.Commands.Sell;
using Dojo.Bakery.Transaction.Application.DTOs.Sell;
using Dojo.Bakery.Transaction.Application.Queries.Sell;

namespace Dojo.Bakery.Transaction.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/Sells")]
    [ApiController]
    public class SellController : BaseController
    {
        private readonly IMediator _mediator;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public SellController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        ///     Action to retrieve all Sale.
        /// </summary>
        /// <remarks>
        /// Sample response:
        ///
        ///     GET /Sale
        ///     {
        ///         "Id": "0070AE1A-5FA4-4AB2-8C45-41873B092B3B",
        ///         "name": "XXXXX"
        ///     }
        ///
        /// </remarks>
        /// <returns>Returns the list of Sales</returns>
        /// <response code="200">Returned if the get process works</response>
        /// <response code="400">Returned if the model couldn't be parsed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<ActionResult<Response>> GetAll()
        {
            return Result(await _mediator.Send(new GetAllSellQuery()));
        }
        /// <summary>
        /// Action to create a Sale
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <response code="200">Returned if the get process works</response>
        /// <response code="400">Returned if the model couldn't be parsed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<Response>> Create([FromBody] SellDto data)
        {
            return Result(await _mediator.Send(new CreateSellCommand() { Item = data }));
        }
    }
}
