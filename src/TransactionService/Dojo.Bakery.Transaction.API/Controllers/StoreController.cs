using Dojo.Bakery.Transaction.Application.Commands.Store;
using Dojo.Bakery.Transaction.Application.DTOs.Store;
using Dojo.Bakery.Transaction.Application.Queries.Store;

namespace Dojo.Bakery.Transaction.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/Stores")]
    [ApiController]
    public class StoreController : BaseController
    {
        private readonly IMediator _mediator;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public StoreController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        ///     Action to retrieve all Store.
        /// </summary>
        /// <remarks>
        /// Sample response:
        ///
        ///     GET /Store
        ///     {
        ///         "Id": "0070AE1A-5FA4-4AB2-8C45-41873B092B3B",
        ///         "name": "XXXXX"
        ///     }
        ///
        /// </remarks>
        /// <returns>Returns the list of Stores</returns>
        /// <response code="200">Returned if the get process works</response>
        /// <response code="400">Returned if the model couldn't be parsed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<ActionResult<Response>> GetAll()
        {
            return Result(await _mediator.Send(new GetAllStoreQuery()));
        }
        /// <summary>
        /// Action to create a Store
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <response code="200">Returned if the get process works</response>
        /// <response code="400">Returned if the model couldn't be parsed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<Response>> Create([FromBody]StoreDto data)
        {
            return Result(await _mediator.Send(new CreateStoreCommand() { Item = data }));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]
        public async Task<ActionResult<Response>> Delete(Guid id)
        {
            return Result(await _mediator.Send(new DeleteStoreCommand() { Id = id }));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<ActionResult<Response>> Update([FromBody] StoreDto data)
        {
            return Result(await _mediator.Send(new UpdateStoreCommand() { Item = data }));
        }
    }
}
