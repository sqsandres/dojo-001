
namespace Dojo.Bakery.Transaction.Application.Handlers.Units;

public class GetAllUnitsQueryHandler : IRequestHandler<GetAllUnitsQuery, List<UnitDto>>
{
    private readonly ILogger<GetAllUnitsQueryHandler> _logger;
    private readonly IUnitRepository _unitRepository;

    public GetAllUnitsQueryHandler(ILogger<GetAllUnitsQueryHandler> logger, IUnitRepository unitRepository)
    {
        _logger = logger;
        _unitRepository = unitRepository;
    }

    public async Task<List<UnitDto>> Handle(GetAllUnitsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Domain.Unit> query = from i in await _unitRepository.GetEntitiesAsync()
                                         orderby i.Name
                                         select i;

        DomainExceptionValidation.When(query == null, "There is not Units");

        List<UnitDto> units = new List<UnitDto>();
        foreach (Domain.Unit item in query.ToList())
        {
            units.Add(new UnitDto()
            {
                Id = item.Id,
                Name = item.Name
            });
        }
        return units;
    }
}
