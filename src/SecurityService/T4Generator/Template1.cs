using MediatR;
using Microsoft.Extensions.Logging;
using RJO.OrderService.Services.DTO;
using RJO.OrderService.Services.Queries;
using RJO.OrderService.Persistence.Contracts.UnitOfWork;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RJO.OrderService.Persistence.Contracts.Repositories;
using RJO.OrderService.Common;

namespace RJO.OrderService.Services.Handlers
{
    public class GetAllCashTransactionQueryHandler : IRequestHandler<GetAllCashTransactionQuery, List<CashTransactionDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly ICashTransactionRepository _CashTransactionRepository;

        public GetAllCashTransactionQueryHandler(IUnitOfWork unitOfWork, ILoggerFactory loggerFactory, ICashTransactionRepository CashTransactionRepository)
        {
            _unitOfWork = unitOfWork;
            _CashTransactionRepository = CashTransactionRepository;
            this._logger = loggerFactory.CreateLogger<GetAllCashTransactionQueryHandler>();
        }
        public async Task<List<CashTransactionDto>> Handle(GetAllCashTransactionQuery request, CancellationToken cancellationToken)
        {
            var result = await _CashTransactionRepository.GetAllEntities();
            this._logger.OrderAll();
            return (from f in result select new CashTransactionDto() { Id=f.Id, Name = f.Name }).ToList();
        }
    }
}
using System;

namespace RJO.OrderService.Services.DTO
{
    public class CashTransactionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
using MediatR;
using RJO.OrderService.Services.DTO;
using System.Collections.Generic;

namespace RJO.OrderService.Services.Queries
{
    public class GetAllCashTransactionQuery : IRequest<List<CashTransactionDto>>
    {
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RJO.OrderService.Services.DTO;
using RJO.OrderService.Services.Queries;

namespace RJO.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/CashTransactions")]
    [ApiController]
    public class CashTransactionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CashTransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        ///     Action to retrieve all CashTransaction.
        /// </summary>
        /// <returns>Returns a list of CashTransaction elements or an empty list</returns>
        /// <response code="200">Returned if the list was retrieved</response>
        /// <response code="400">Returned if the elements could not be retrieved</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<ActionResult<List<CashTransactionDto>>> GetAll()
        {
            return await _mediator.Send(new GetAllCashTransactionQuery());
        }
    }
}
