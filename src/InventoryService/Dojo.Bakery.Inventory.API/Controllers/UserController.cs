using Dojo.Bakery.BuildingBlocks.WebCommons;
using Dojo.Bakery.BuildingBlocks.WebCommons.Models;
using Dojo.Bakery.Inventory.Application.Commands.User;
using Dojo.Bakery.Inventory.Application.DTOs.User;
using Dojo.Bakery.Inventory.Application.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dojo.Bakery.Inventory.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IMediator _mediator;
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
        /// <summary>
        /// Action to create a User
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <response code="200">Returned if the get process works</response>
        /// <response code="400">Returned if the model couldn't be parsed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<Response>> Create([FromBody]UserDto data)
        {
            return Result(await _mediator.Send(new CreateUserCommand() { Item = data }));
        }
    }
}
