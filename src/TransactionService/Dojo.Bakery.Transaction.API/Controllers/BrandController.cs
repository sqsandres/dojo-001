
namespace Dojo.Bakery.Transaction.API.Controllers;

[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
public class BrandController : BaseController
{
    private readonly IMediator _mediator;
    public BrandController(IMediator mediator)
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
    /// <returns>Returns the list of Brands</returns>
    /// <response code="200">Returned if the get process works</response>
    /// <response code="400">Returned if the model couldn't be parsed</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<ActionResult<Response>> GetAll()
    {
        return Result(await _mediator.Send(new GetAllBrandsQuery()));
    }
    /// <summary>
    /// Action to create a Brand
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    /// <response code="200">Returned if the get process works</response>
    /// <response code="400">Returned if the model couldn't be parsed</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<Response>> Create([FromBody] BrandDto data)
    {
        return Result(await _mediator.Send(new CreateBrandCommand() { Item = data }));
    }


    /// <summary>
    /// Action to Update a Brand
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    /// <response code="200">Returned if the get process works</response>
    /// <response code="400">Returned if the model couldn't be parsed</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult<Response>> Update([FromBody] BrandDto data)
    {
        return Result(await _mediator.Send(new UpdateBrandCommand() { Item = data }));
    }

    /// <summary>
    /// Action to delete a Brand
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    /// <response code="200">Returned if the get process works</response>
    /// <response code="400">Returned if the model couldn't be parsed</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("{Id}")]
    public async Task<ActionResult<Response>> Delete(Guid Id)
    {
        return Result(await _mediator.Send(new RemoveBrandCommand() { Id = Id }));
    }
}
