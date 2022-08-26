
namespace Dojo.Bakery.Transaction.API.Controllers;

[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
public class SupplierController : BaseController
{
    private readonly IMediator _mediator;
    public SupplierController(IMediator mediator)
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
    /// <returns>Returns the list of Suppliers</returns>
    /// <response code="200">Returned if the get process works</response>
    /// <response code="400">Returned if the model couldn't be parsed</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<ActionResult<Response>> GetAll()
    {
        return Result(await _mediator.Send(new GetAllSuppliersQuery()));
    }
    /// <summary>
    /// Action to create a Supplier
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    /// <response code="200">Returned if the get process works</response>
    /// <response code="400">Returned if the model couldn't be parsed</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<Response>> Create([FromBody] SupplierDto data)
    {
        return Result(await _mediator.Send(new CreateSupplierCommand() { Item = data }));
    }


    /// <summary>
    /// Action to Update a Supplier
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    /// <response code="200">Returned if the get process works</response>
    /// <response code="400">Returned if the model couldn't be parsed</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult<Response>> Update([FromBody] SupplierDto data)
    {
        return Result(await _mediator.Send(new UpdateSupplierCommand() { Item = data }));
    }

    /// <summary>
    /// Action to delete a Supplier
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    /// <response code="200">Returned if the get process works</response>
    /// <response code="400">Returned if the model couldn't be parsed</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("{Id}")]
    public async Task<ActionResult<Response>> Delete(Guid Id)
    {
        return Result(await _mediator.Send(new RemoveSupplierCommand() { Id = Id }));
    }
}
