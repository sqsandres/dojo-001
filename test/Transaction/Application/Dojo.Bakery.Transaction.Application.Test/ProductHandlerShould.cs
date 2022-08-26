
namespace Dojo.Bakery.Transaction.Application.Test;

public class ProductHandlerShould
{
    private readonly Mock<IUnitOfWork> unitOfWorkMock;
    private readonly Mock<IProductRepository> productRepositoryMock;
    public ProductHandlerShould()
    {
        unitOfWorkMock = new Mock<IUnitOfWork>();
        productRepositoryMock = new Mock<IProductRepository>();
    }
    #region Commands

    [Fact]
    public async void CreateValidProductCommandHandler()
    {
        var loggerMock = new Mock<ILogger<CreateProductCommandHandler>>();

        var productCommandHandler = new CreateProductCommandHandler(loggerMock.Object, productRepositoryMock.Object, unitOfWorkMock.Object);
        var command = new CreateProductCommand() { Item = ProductFakeData.GetProduct };

        var result = await productCommandHandler.Handle(command, CancellationToken.None);

        Assert.IsType<Guid>(result);
    }   


    [Fact]
    public async void CreateProductCommandHandler_Invalid_Request_DomainExceptionValidation()
    {
        
        var loggerMock = new Mock<ILogger<CreateProductCommandHandler>>();

        var productCommandHandler = new CreateProductCommandHandler(loggerMock.Object, productRepositoryMock.Object, unitOfWorkMock.Object);
        var request = new CreateProductCommand() { Item = null };
        

        var domainException = await Assert.ThrowsAsync<DomainExceptionValidation>
              (async () =>
                  await productCommandHandler.Handle(request, CancellationToken.None)
              );

        Assert.Equal("Creation data is required", domainException.Message);
    }

    [Fact]
    public async void CreateProductCommandHandler_Invalid_Name_DomainExceptionValidation()
    {

        var loggerMock = new Mock<ILogger<CreateProductCommandHandler>>();

        var productCommandHandler = new CreateProductCommandHandler(loggerMock.Object, productRepositoryMock.Object, unitOfWorkMock.Object);
        var request = new CreateProductCommand() { Item = ProductFakeData.GetInvalidProductName };


        var domainException = await Assert.ThrowsAsync<DomainExceptionValidation>
              (async () =>
                  await productCommandHandler.Handle(request, CancellationToken.None)
              );

        Assert.Equal("name value is required", domainException.Message);
    }

    [Fact]
    public async void CreateProductCommandHandler_Invalid_UnitPrice_DomainExceptionValidation()
    {

        var loggerMock = new Mock<ILogger<CreateProductCommandHandler>>();

        var productCommandHandler = new CreateProductCommandHandler(loggerMock.Object, productRepositoryMock.Object, unitOfWorkMock.Object);
        var request = new CreateProductCommand() { Item = ProductFakeData.GetInvalidProductUnitPrice };


        var domainException = await Assert.ThrowsAsync<DomainExceptionValidation>
              (async () =>
                  await productCommandHandler.Handle(request, CancellationToken.None)
              );

        Assert.Equal("unitPrice value is required", domainException.Message);
    }



    #endregion

    #region Queries

    [Fact]
    public async void GetllAllProducts_QueryHandler()
    {
        var loggerMock = new Mock<ILogger<GetAllProductsQueryHandler>>();

        productRepositoryMock.Setup(p => p.GetEntitiesAsync()).ReturnsAsync(ProductFakeData.GetProducts);
        var productQueryHandler = new GetAllProductsQueryHandler(loggerMock.Object, productRepositoryMock.Object);
        var request = new GetAllProductsQuery() { };

        var result = await productQueryHandler.Handle(request, CancellationToken.None);
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
    }


    [Fact]
    public async void GetllAllProducts_Is_Empty_DomainExceptionValidation()
    {
        var loggerMock = new Mock<ILogger<GetAllProductsQueryHandler>>();
        var productRepositoryMock = new Mock<IProductRepository>();

        var productQueryHandler = new GetAllProductsQueryHandler(loggerMock.Object, productRepositoryMock.Object);
        var request = new GetAllProductsQuery() { };

        var domainException = await Assert.ThrowsAsync<DomainExceptionValidation>
              (async () =>
                  await productQueryHandler.Handle(request, CancellationToken.None)
              );
        Assert.Equal("There is not products", domainException.Message);
    }

    [Fact]
    public async void GetProductById_Not_Found_DomainExceptionValidation()
    {
        var loggerMock = new Mock<ILogger<GetProductByIdQueryHandler>>();
        var productRepositoryMock = new Mock<IProductRepository>();

        productRepositoryMock.Setup(p => p.GetByIdAsync(new Guid())).ReturnsAsync(ProductFakeData.GetProducts.First());
        var productQueryHandler = new GetProductByIdQueryHandler(loggerMock.Object, productRepositoryMock.Object);
        var request = new GetProductByIdQuery() { Id = ProductFakeData.GetProducts.First().Id };

        var domainException = await Assert.ThrowsAsync<DomainExceptionValidation>
              (async () =>
                  await productQueryHandler.Handle(request, CancellationToken.None)
              );
        Assert.Equal("Product not found", domainException.Message);
    }

    #endregion







}
