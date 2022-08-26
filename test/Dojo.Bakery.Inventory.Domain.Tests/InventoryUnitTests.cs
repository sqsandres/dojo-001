using Dojo.Bakery.BuildingBlocks.Commons;
using System;
using Xunit;

namespace Dojo.Bakery.Inventory.Domain.Tests
{
    public class InventoryUnitTests
    {
        private const int _productQuantity = 10;
        private const string NO_PRODUCTS_IN_STOCK_MESSAGE = "There is not products in the inventory";
        private const string NO_ENOUGH_PRODUCTS_IN_STOCK_MESSAGE = "There is not enough products in the inventory for the operation";
        private readonly Guid _productId = new Guid("1e4e73bb-1469-42e9-9a69-1a14ce70bf7b");
        private readonly Guid _storeId = new Guid("9f411f76-42d9-4f1f-ad0c-5d8c06cabaea");
        private readonly int _stock = 20;

        [Fact]
        public void Create_inventory_instance()
        {
            // Arrange 
            Domain.Entities.Inventory instance;

            // Act
            instance = new Domain.Entities.Inventory(_productId, _storeId, _stock);

            // Asset
            Assert.NotNull(instance);
            Assert.NotEqual(instance.Id, Guid.Empty);
            Assert.Equal(_stock, instance.Stock);
            Assert.Equal(_productId, instance.ProductId);   
            Assert.Equal(_storeId, instance.StoreId);   
        }

        [Fact]
        public void Increse_stock()
        {
            // Arrange 
            var expectedQuantity = _stock + _productQuantity;
            Domain.Entities.Inventory instance;
            instance = new Domain.Entities.Inventory(_productId, _storeId, _stock);

            // Act
            instance.IncreaseStock(_productQuantity);

            // Asset
            Assert.NotNull(instance);
            Assert.NotEqual(instance.Id, Guid.Empty);
            Assert.Equal(_productId, instance.ProductId);
            Assert.Equal(_storeId, instance.StoreId);
            Assert.Equal(expectedQuantity, instance.Stock);
        }

        [Fact]
        public void Decrese_stock()
        {
            // Arrange 
            var expectedQuantity = _stock - _productQuantity;
            Domain.Entities.Inventory instance;
            instance = new Domain.Entities.Inventory(_productId, _storeId, _stock);

            // Act
            instance.DecreaseStock(_productQuantity);

            // Asset
            Assert.NotNull(instance);
            Assert.NotEqual(instance.Id, Guid.Empty);
            Assert.Equal(_productId, instance.ProductId);
            Assert.Equal(_storeId, instance.StoreId);
            Assert.Equal(expectedQuantity, instance.Stock);
        }

        [Fact]
        public void Decrese_stock_with_stock_in_zero()
        {
            // Arrange 
            var stock = 0;
            Domain.Entities.Inventory instance;
            instance = new Domain.Entities.Inventory(_productId, _storeId, stock);

            // Act
            Action act = () => instance.DecreaseStock(_productQuantity);

            // Asset
            DomainExceptionValidation exception = Assert.Throws<DomainExceptionValidation>(act);
            Assert.Equal(NO_PRODUCTS_IN_STOCK_MESSAGE, exception.Message);
        }

        [Fact]
        public void Decrese_stock_with_no_enough_stock()
        {
            // Arrange 
            var stock = 5;
            Domain.Entities.Inventory instance;
            instance = new Domain.Entities.Inventory(_productId, _storeId, stock);

            // Act
            Action act = () => instance.DecreaseStock(_productQuantity);

            // Asset
            DomainExceptionValidation exception = Assert.Throws<DomainExceptionValidation>(act);
            Assert.Equal(NO_ENOUGH_PRODUCTS_IN_STOCK_MESSAGE, exception.Message);
        }

        [Fact]
        public void Change_productId()
        {
            // Arrange 
            var expectedProductId = new Guid("1f411f76-42d9-4f1f-ad0c-5d8c06cabaae");
            Domain.Entities.Inventory instance;
            instance = new Domain.Entities.Inventory(_productId, _storeId, _stock);

            // Act
            instance.ChangeProductId(expectedProductId);

            // Asset
            Assert.NotNull(instance);
            Assert.NotEqual(instance.Id, Guid.Empty);
            Assert.Equal(_storeId, instance.StoreId);
            Assert.Equal(expectedProductId, instance.ProductId);
        }

        [Fact]
        public void Change_StoreId()
        {
            // Arrange 
            var expectedStoreId = new Guid("1f411f76-42d9-4f1f-ad0c-5d8c06cabaae");
            Domain.Entities.Inventory instance;
            instance = new Domain.Entities.Inventory(_productId, _storeId, _stock);

            // Act
            instance.ChangeStoreId(expectedStoreId);

            // Asset
            Assert.NotNull(instance);
            Assert.NotEqual(instance.Id, Guid.Empty);
            Assert.Equal(_productId, instance.ProductId);
            Assert.Equal(expectedStoreId, instance.StoreId);
        }

        [Fact]
        public void Catch_domailException_when_create_inventory_instance_with_storeId_empty()
        {
            // Arrange 
            Domain.Entities.Inventory instance;

            // Act
            Action act = () => instance = new Domain.Entities.Inventory(_productId,Guid.Empty, _stock);

            // Asset
            DomainExceptionValidation exception = Assert.Throws<DomainExceptionValidation>(act);
            Assert.Equal("storeId cannot be empty", exception.Message);
        }


        [Fact]
        public void Catch_domailException_when_create_inventory_instance_with_productId_empty()
        {
            // Arrange 
            Domain.Entities.Inventory instance;

            // Act
            Action act = () => instance = new Domain.Entities.Inventory(Guid.Empty, _storeId, _stock);

            // Asset
            DomainExceptionValidation exception = Assert.Throws<DomainExceptionValidation>(act);
            Assert.Equal("productId cannot be empty", exception.Message);
        }

        [Fact]
        public void Create_inventory_instance_stock_must_not_be_less_than_zero()
        {
            // Arrange 
            Domain.Entities.Inventory instance;

            // Act
            Action act = () => instance = new Domain.Entities.Inventory(_productId, _storeId, -1);

            // Asset
            DomainExceptionValidation exception = Assert.Throws<DomainExceptionValidation>(act);
            Assert.Equal("The stock cannot be less than zero", exception.Message);
        }

    }
}