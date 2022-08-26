using Dojo.Bakery.BuildingBlocks.WebCommons;
using Dojo.Bakery.BuildingBlocks.WebCommons.Models;
using Dojo.Bakery.Inventory.Application.DTOs.DocumentType;
using Dojo.Bakery.Inventory.Application.Queries.DocumentType;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dojo.Bakery.Inventory.API.Controllers
{
    [Produces("application/json")]
    [Route("api/DocumentTypes")]
    [ApiController]
    public class DocumentTypeController : BaseController
    {
        private readonly IMediator _mediator;
        public DocumentTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        ///     Action to retrieve all DocumentType.
        /// </summary>
        /// <remarks>
        /// Sample response:
        ///
        ///     GET /DocumentType
        ///     {
        ///         "Id": "0070AE1A-5FA4-4AB2-8C45-41873B092B3B",
        ///         "name": "XXXXX"
        ///     }
        ///
        /// </remarks>
        /// <returns>Returns the list of DocumentTypes</returns>
        /// <response code="200">Returned if the get process works</response>
        /// <response code="400">Returned if the model couldn't be parsed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<ActionResult<Response>> GetAll()
        {
            return Result(await _mediator.Send(new GetAllDocumentTypeQuery()));
        }
    }
}
