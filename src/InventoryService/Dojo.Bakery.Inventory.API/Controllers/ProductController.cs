using Dojo.Bakery.BuildingBlocks.WebCommons;
using Dojo.Bakery.BuildingBlocks.WebCommons.Models;
using Dojo.Bakery.Inventory.Application.Commands.Products;
using Dojo.Bakery.Inventory.Application.DTOs.Products;
using Dojo.Bakery.Inventory.Application.Queries.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dojo.Bakery.Inventory.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
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
            return Result(await _mediator.Send(new GetAllProductsQuery()));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <response code="200">Returned if the get process works</response>
        /// <response code="400">Returned if the model couldn't be parsed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<Response>> Create([FromBody] ProductDto data)
        {
            return Result(await _mediator.Send(new CreateProductCommand() { Item = data }));
        }
    }
}
