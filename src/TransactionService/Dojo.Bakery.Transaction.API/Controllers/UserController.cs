using Dojo.Bakery.Transaction.Application.Queries.User;

namespace Dojo.Bakery.Transaction.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/Users")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IMediator _mediator;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        ///     Action to retrieve all User.
        /// </summary>
        /// <remarks>
        /// Sample response:
        ///
        ///     GET /User
        ///     {
        ///         "Id": "0070AE1A-5FA4-4AB2-8C45-41873B092B3B",
        ///         "name": "XXXXX"
        ///     }
        ///
        /// </remarks>
        /// <returns>Returns the list of Users</returns>
        /// <response code="200">Returned if the get process works</response>
        /// <response code="400">Returned if the model couldn't be parsed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<ActionResult<Response>> GetAll()
        {
            return Result(await _mediator.Send(new GetAllUserQuery()));
        }
    }
}
