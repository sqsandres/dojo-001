using Microsoft.Extensions.Logging;
using Dojo.Bakery.Inventory.Application.Handlers.Inventory;
using Moq;
using Dojo.Bakery.Inventory.Infra.DataContract;
using Dojo.Bakery.BuildingBlocks.Commons.Repositories;
using Dojo.Bakery.Inventory.Application.Tests.Fakes;

namespace Dojo.Bakery.Inventory.Application.Tests
{
    public class InventoryHandlerUnitTest
    {
        private Mock<ILogger<CreateInventoryItemCommandHandler>> _logger;
        private Mock<IInventoryRepository> _inventoryRepository;
        private Mock<IUnitOfWork> _unitOfWork;

        public InventoryHandlerUnitTest()
        {
            _logger = new Mock<ILogger<CreateInventoryItemCommandHandler>>();
            _inventoryRepository = new Mock<IInventoryRepository>();    
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        [Fact]
        public void Create_inventory_item()
        {
            // Arrange
            CreateInventoryItemCommandHandler _handler = new CreateInventoryItemCommandHandler(_logger.Object, _inventoryRepository.Object, _unitOfWork.Object);

            // Act
            var guid = _handler.Handle(InventoryItemCommandFakeData.CreateInventoryItemCommand, CancellationToken.None).Result;

            // Asserts
            Assert.NotNull(guid);
            Assert.False(guid == Guid.Empty);
        }
    }
}