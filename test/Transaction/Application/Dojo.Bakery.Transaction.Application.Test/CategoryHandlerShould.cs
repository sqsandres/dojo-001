
namespace Dojo.Bakery.Transaction.Application.Test;

public class CategoryHandlerShould
{
    [Fact]
    public async void CreateValidCategoryCommandHandler()
    {
        
        var command = new CreateCategoryCommand() { Item = new CategoryDto() { Name = "Abarrotes" } };
        var loggerMock = new Mock<ILogger<CreateCategoryCommandHandler>>();
        var categoryRepositoryMock = new Mock<ICategoryRepository>();
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        
        var createCategoryCommandHandler = new CreateCategoryCommandHandler(loggerMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);
        
        var result = await createCategoryCommandHandler.Handle(command, CancellationToken.None);

        Assert.IsType<Guid>(result);
    }

    [Fact]
    public async void CreateCategoryCommandHandler_Invalid_Name_DomainExceptionValidation()
    {        
        var loggerMock = new Mock<ILogger<CreateCategoryCommandHandler>>();
        var categoryRepositoryMock = new Mock<ICategoryRepository>();
        var unitOfWorkMock = new Mock<IUnitOfWork>();

        var createCategoryCommandHandler = new CreateCategoryCommandHandler(loggerMock.Object, categoryRepositoryMock.Object, unitOfWorkMock.Object);
        var command = new CreateCategoryCommand() { Item = new CategoryDto() { Name = string.Empty } };

        var domainException = await Assert.ThrowsAsync<DomainExceptionValidation>
            ( async () =>
                await createCategoryCommandHandler.Handle(command, CancellationToken.None)
            );

        Assert.Equal("name value is required", domainException.Message);
    }
}
