
namespace Dojo.Bakery.Transaction.Application.Test;

public class BrandHandlerShould
{
    private readonly Mock<IUnitOfWork> unitOfWorkMock;
    private readonly Mock<IBrandRepository> brandRepositoryMock;

    public BrandHandlerShould()
    {
        brandRepositoryMock = new Mock<IBrandRepository>();
        unitOfWorkMock = new Mock<IUnitOfWork>();
    }

    #region Commands
    [Fact]
    public async void CreateValidBrandCommandHandler()
    {   
        var loggerMock = new Mock<ILogger<CreateBrandCommandHandler>>();
       
        brandRepositoryMock.Setup(x => x.CreateAsync(new Brand("Harina")));
        var createBrandCommandHandler = new CreateBrandCommandHandler(loggerMock.Object, brandRepositoryMock.Object, unitOfWorkMock.Object);

        var request = new CreateBrandCommand() { Item = new BrandDto() { Name = "Harina" } };
        var result = await createBrandCommandHandler.Handle(request, CancellationToken.None);

        Assert.IsType<Guid>(result);
    }

    [Fact]
    public async void CreateBrandCommandHandler_Invalid_Name_DomainExceptionValidation()
    {        

        var loggerMock = new Mock<ILogger<CreateBrandCommandHandler>>();        

        var createBrandCommandHandler = new CreateBrandCommandHandler(loggerMock.Object, brandRepositoryMock.Object, unitOfWorkMock.Object);
        var request = new CreateBrandCommand() { Item = new BrandDto() { Name = string.Empty } };

        var domainException = await Assert.ThrowsAsync<DomainExceptionValidation>
            ( async () =>
                await createBrandCommandHandler.Handle(request, CancellationToken.None)
            );

        Assert.Equal("name value is required", domainException.Message);
    }

    [Fact]
    public async void UpdateBrandCommandHandler()
    {
        var loggerMock = new Mock<ILogger<UpdateBrandCommandHandler>>();      

        var brand = BrandFakeData.GetBrands.First();
        brandRepositoryMock.Setup(b => b.GetByIdAsync(brand.Id)).ReturnsAsync(brand);
        brandRepositoryMock.Setup(b => b.UpdateAsync(BrandFakeData.GetBrands.First())).Verifiable();

        var updateBrandCommandHandler = new UpdateBrandCommandHandler(loggerMock.Object, brandRepositoryMock.Object, unitOfWorkMock.Object);
        var request = new UpdateBrandCommand() { Item = new BrandDto() { Name = "Colanta", Id = brand.Id } };

        var result = await updateBrandCommandHandler.Handle(request, CancellationToken.None);
        Assert.Equal(brand.Id, result);

    }

    [Fact]
    public async void UpdateBrandCommandHandler_DomainExceptionValidation()
    {
        var loggerMock = new Mock<ILogger<UpdateBrandCommandHandler>>();
        var updateBrandCommandHandler = new UpdateBrandCommandHandler(loggerMock.Object, brandRepositoryMock.Object, unitOfWorkMock.Object);
        var request = new UpdateBrandCommand();

        var domainException = await Assert.ThrowsAsync<DomainExceptionValidation>
            (async () =>
                await updateBrandCommandHandler.Handle(request, CancellationToken.None)
            );

        Assert.Equal("Update Brand data is required", domainException.Message);
    }

    [Fact]
    public async void RemoveBrandCommandHandler_Not_Found_DomainExceptionValidation()
    {
        var loggerMock = new Mock<ILogger<RemoveBrandCommandHandler>>();
        brandRepositoryMock.Setup(b => b.GetByIdAsync(Guid.NewGuid()));
        var removeBrandCommandHandler = new RemoveBrandCommandHandler(loggerMock.Object, brandRepositoryMock.Object, unitOfWorkMock.Object);
        var request = new RemoveBrandCommand() { Id = Guid.NewGuid()};

        var domainException = await Assert.ThrowsAsync<DomainExceptionValidation>
            (async () =>
                await removeBrandCommandHandler.Handle(request, CancellationToken.None)
            );

        Assert.Equal("Brand not found", domainException.Message);
    }


    [Fact]
    public async void RemoveBrandCommandHandler_Required_Data_DomainExceptionValidation()
    {
        var loggerMock = new Mock<ILogger<RemoveBrandCommandHandler>>();
        var removeBrandCommandHandler = new RemoveBrandCommandHandler(loggerMock.Object, brandRepositoryMock.Object, unitOfWorkMock.Object);
        var request = new RemoveBrandCommand() { Id = new Guid() };

        var domainException = await Assert.ThrowsAsync<DomainExceptionValidation>
            (async () =>
                await removeBrandCommandHandler.Handle(request, CancellationToken.None)
            );

        Assert.Equal("Brand data is required", domainException.Message);
    }


    #endregion

    #region Queries
    [Fact]
    public async void GetllAllBrands_Is_Empty_DomainExceptionValidation()
    {
        var loggerMock = new Mock<ILogger<GetAllBrandsQueryHandler>>();

        var brandQueryHandler = new GetAllBrandsQueryHandler(loggerMock.Object, brandRepositoryMock.Object);
        var request = new GetAllBrandsQuery() { };

        var domainException = await Assert.ThrowsAsync<DomainExceptionValidation>
              (async () =>
                  await brandQueryHandler.Handle(request, CancellationToken.None)
              );
        Assert.Equal("There is not brands", domainException.Message);
    }

    [Fact]
    public async void GetllAllBrands_QueryHandler()
    {        

        var loggerMock = new Mock<ILogger<GetAllBrandsQueryHandler>>();

        brandRepositoryMock.Setup(p => p.GetEntitiesAsync()).ReturnsAsync(BrandFakeData.GetBrands);
        var brandQueryHandler = new GetAllBrandsQueryHandler(loggerMock.Object, brandRepositoryMock.Object);
        var request = new GetAllBrandsQuery() { };

        var result = await brandQueryHandler.Handle(request, CancellationToken.None);
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async void GetBrandById_QueryHandler()
    {

        var loggerMock = new Mock<ILogger<GetBrandByIdQueryHandler>>();

        var guid = BrandFakeData.GetBrands.First().Id;

        brandRepositoryMock.Setup(p => p.GetByIdAsync(guid)).ReturnsAsync(BrandFakeData.GetBrands.First());
        var brandQueryHandler = new GetBrandByIdQueryHandler(loggerMock.Object, brandRepositoryMock.Object);
        var request = new GetBrandByIdQuery() { Id = guid };

        var result = await brandQueryHandler.Handle(request, CancellationToken.None);
        Assert.NotNull(result);
        Assert.Equal("Celema", result.Name);
    }

    [Fact]
    public async void GetBrandById_Not_Found_DomainExceptionValidation()
    {
        var loggerMock = new Mock<ILogger<GetBrandByIdQueryHandler>>();

        brandRepositoryMock.Setup(p => p.GetByIdAsync(Guid.NewGuid())).ReturnsAsync(BrandFakeData.GetBrands.First());
        var brandQueryHandler = new GetBrandByIdQueryHandler(loggerMock.Object, brandRepositoryMock.Object);
        var request = new GetBrandByIdQuery() { Id = Guid.NewGuid() };

        var domainException = await Assert.ThrowsAsync<DomainExceptionValidation>
              (async () =>
                  await brandQueryHandler.Handle(request, CancellationToken.None)
              );
        Assert.Equal("Brand not found", domainException.Message);
    }
    #endregion
}
