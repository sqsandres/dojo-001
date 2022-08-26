namespace Dojo.Bakery.Transaction.API.Controllers;

[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
public class CategoryController : BaseController
{
    private readonly IMediator _mediator;
    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }


    /// <summary>
    ///     Action to retrieve a contract in detail with related entities.
    /// </summary>
    /// <remarks>
    /// Sample response:
    ///
    ///     GET /ContractDto
    ///     {
    ///         "Id": "0070AE1A-5FA4-4AB2-8C45-41873B092B3B",
    ///         "name": "XXXXX"
    ///     }
    ///
    /// </remarks>
    /// <returns>Returns the list of products</returns>
    /// <response code="200">Returned if the get process works</response>
    /// <response code="400">Returned if the model couldn't be parsed</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<ActionResult<Response>> Get()
    {
        return Result(await _mediator.Send(new GetAllCategoriesQuery()));
    }

    /// <summary>
    ///     Action to retrieve a contract in detail with related entities.
    /// </summary>
    /// <remarks>
    /// Sample response:
    ///
    ///     GET /ContractDto
    ///     {
    ///         "Id": "0070AE1A-5FA4-4AB2-8C45-41873B092B3B",
    ///         "name": "XXXXX"
    ///     }
    ///
    /// </remarks>
    /// <param name="Id"></param>
    /// <returns>Returns the list of Categories</returns>
    /// <response code="200">Returned if the get process works</response>
    /// <response code="400">Returned if the model couldn't be parsed</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("Id")]
    public async Task<ActionResult<Response>> Get(Guid Id)
    {
        return Result(await _mediator.Send(new GetCategoryByIdQuery() { Id = Id}));
    }


    /// <summary>
    /// Action to create a Category
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    /// <response code="200">Returned if the get process works</response>
    /// <response code="400">Returned if the model couldn't be parsed</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<Response>> Create([FromBody] CategoryDto data)
    {
        return Result(await _mediator.Send(new CreateCategoryCommand() { Item = data }));
    }

    /// <summary>
    /// Action to Update a Category
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    /// <response code="200">Returned if the get process works</response>
    /// <response code="400">Returned if the model couldn't be parsed</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult<Response>> Update([FromBody] CategoryDto data)
    {
        return Result(await _mediator.Send(new UpdateCategoryCommand() { Item = data}));
    }

    /// <summary>
    /// Action to delete a Category
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
        return Result(await _mediator.Send(new RemoveCategoryCommand(){ Id = id }));
    }

}
