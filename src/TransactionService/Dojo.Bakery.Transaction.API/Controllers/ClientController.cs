
namespace Dojo.Bakery.Transaction.API.Controllers;

[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
public class ClientController : BaseController
{
    private readonly IMediator _mediator;
    public ClientController(IMediator mediator)
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
    /// <returns>Returns the list of Clients</returns>
    /// <response code="200">Returned if the get process works</response>
    /// <response code="400">Returned if the model couldn't be parsed</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<ActionResult<Response>> GetAll()
    {
        return Result(await _mediator.Send(new GetAllClientsQuery()));
    }
    /// <summary>
    /// Action to create a Client
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    /// <response code="200">Returned if the get process works</response>
    /// <response code="400">Returned if the model couldn't be parsed</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<Response>> Create([FromBody] ClientDto data)
    {
        return Result(await _mediator.Send(new CreateClientCommand() { Item = data }));
    }

    /// <summary>
    /// Action to Update a Client
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    /// <response code="200">Returned if the get process works</response>
    /// <response code="400">Returned if the model couldn't be parsed</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult<Response>> Update([FromBody] ClientDto data)
    {
        return Result(await _mediator.Send(new UpdateClientCommand() { Item = data }));
    }

    /// <summary>
    /// Action to delete a Client
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    /// <response code="200">Returned if the get process works</response>
    /// <response code="400">Returned if the model couldn't be parsed</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("{Id}")]
    public async Task<ActionResult<Response>> Delete(Guid id)
    {
        return Result(await _mediator.Send(new RemoveClientCommand() { Id = id }));
    }
}
