
namespace Dojo.Bakery.Transaction.Application.Test;

public class UnitHandlerShould
{
    private readonly Mock<IUnitRepository> unitRepositoryMock;

    public UnitHandlerShould()
    {
        unitRepositoryMock = new Mock<IUnitRepository>();
    }

    [Fact]
    public async void GetAllUnits()
    {
        var loggerMock = new Mock<ILogger<GetAllUnitsQueryHandler>>();
        unitRepositoryMock.Setup(x => x.GetEntitiesAsync()).ReturnsAsync(UnitFakeData.GetUnit);

        var unitQueryHandler = new GetAllUnitsQueryHandler(loggerMock.Object, unitRepositoryMock.Object);
        var request = new GetAllUnitsQuery();

        var result = await unitQueryHandler.Handle(request, CancellationToken.None);
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
    }

    [Fact]
    public async void GetAllUnits_Is_Empty_DomainExceptionValidation()
    {
        var loggerMock = new Mock<ILogger<GetAllUnitsQueryHandler>>();

        var unitQueryHandler = new GetAllUnitsQueryHandler(loggerMock.Object, unitRepositoryMock.Object);
        var request = new GetAllUnitsQuery();

        var domainException = await Assert.ThrowsAsync<DomainExceptionValidation>
              (async () =>
                  await unitQueryHandler.Handle(request, CancellationToken.None)
              );
        Assert.Equal("There is not Units", domainException.Message);
    }
}
