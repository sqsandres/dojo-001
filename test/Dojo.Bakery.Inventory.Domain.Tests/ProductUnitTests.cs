using Dojo.Bakery.BuildingBlocks.Commons;
using System;
using Xunit;

namespace Dojo.Bakery.Inventory.Domain.Tests
{
    public class ProductUnitTests
    {
        private readonly Guid _productId = new Guid("1e4e73bb-1469-42e9-9a69-1a14ce70bf7b");
        private readonly Guid _unitId = new Guid("9f411f76-42d9-4f1f-ad0c-5d8c06cabaea");
        private readonly Guid _brandId = new Guid("9f411f76-42d9-4f1f-ad0c-5d8c06cabaeb");
        private readonly Guid _categoryId = new Guid("9f411f76-42d9-4f1f-ad0c-5d8c06cababb");
        private readonly string _qrCode = "123456789";
        private readonly string _name = "ocanero";
        private const string NULL_OR_EMPTY_ENDING_DESCRIPTION = "cannot be null or empty";
        private const string NAME_NULL_OR_EMPTY_MESSAGE = "name " + NULL_OR_EMPTY_ENDING_DESCRIPTION;
        private const string QRCODE_NULL_OR_EMPTY_MESSAGE = "qrCode " + NULL_OR_EMPTY_ENDING_DESCRIPTION;
        private const string UNIT_ID_REQUIRED_MESSAGE = "The Unit Id is required";
        private const string CATEGORY_ID_REQUIRED_MESSAGE = "The Category Id is required";
        private const string BRAND_ID_REQUIRED_MESSAGE = "The Brand Id is required";

        [Fact]
        public void Change_unitId()
        {
            // Arrange 
            var expected = new Guid("1f411f76-42d9-4f1f-ad0c-5d8c06cabaee");
            Domain.Entities.Product instance = new Domain.Entities.Product(_productId, _qrCode, _name, _unitId, _categoryId, _brandId);

            // Act
            instance.ChangeUnit(expected);

            // Asserts
            Assert.NotNull(instance);
            Assert.Equal(instance.Id, _productId);
            Assert.Equal(instance.QRCode, _qrCode);
            Assert.Equal(instance.Name, _name);
            Assert.Equal(instance.UnitId, expected);
            Assert.Equal(instance.CategoryId, _categoryId);
            Assert.Equal(instance.BrandId, _brandId);
        }

        [Fact]
        public void Catch_exception_when_set_unitId_empty()
        {
            // Arrange 
            Domain.Entities.Product instance = new Domain.Entities.Product(_productId, _qrCode, _name, _unitId, _categoryId, _brandId);

            // Act
            Action action = () => instance.ChangeUnit(Guid.Empty);

            // Asserts
            var exception = Assert.Throws<DomainExceptionValidation>(() => action());
            Assert.Equal(UNIT_ID_REQUIRED_MESSAGE, exception.Message);
        }

        [Fact]
        public void Change_categoryId()
        {
            // Arrange 
            var expected = new Guid("1f411f76-42d9-4f1f-ad0c-5d8c06cabaee");
            Domain.Entities.Product instance = new Domain.Entities.Product(_productId, _qrCode, _name, _unitId, _categoryId, _brandId);

            // Act
            instance.ChangeCategory(expected);

            // Asserts
            Assert.NotNull(instance);
            Assert.Equal(instance.Id, _productId);
            Assert.Equal(instance.QRCode, _qrCode);
            Assert.Equal(instance.Name, _name);
            Assert.Equal(instance.UnitId, _unitId);
            Assert.Equal(instance.CategoryId, expected);
            Assert.Equal(instance.BrandId, _brandId);
        }

        [Fact]
        public void Catch_exception_when_set_categoryId_empty()
        {
            // Arrange 
            Domain.Entities.Product instance = new Domain.Entities.Product(_productId, _qrCode, _name, _unitId, _categoryId, _brandId);

            // Act
            Action action = () => instance.ChangeCategory(Guid.Empty);

            // Asserts
            var exception = Assert.Throws<DomainExceptionValidation>(() => action());
            Assert.Equal(CATEGORY_ID_REQUIRED_MESSAGE, exception.Message);
        }

        [Fact]
        public void Change_brandId()
        {
            // Arrange 
            var expected = new Guid("1f411f76-42d9-4f1f-ad0c-5d8c06cabaee");
            Domain.Entities.Product instance = new Domain.Entities.Product(_productId, _qrCode, _name, _unitId, _categoryId, _brandId);

            // Act
            instance.ChangeBrand(expected);

            // Asserts
            Assert.NotNull(instance);
            Assert.Equal(instance.Id, _productId);
            Assert.Equal(instance.QRCode, _qrCode);
            Assert.Equal(instance.Name, _name);
            Assert.Equal(instance.UnitId, _unitId);
            Assert.Equal(instance.CategoryId, _categoryId);
            Assert.Equal(instance.BrandId, expected);
        }

        [Fact]
        public void Catch_exception_when_set_brandId_empty()
        {
            // Arrange 
            Domain.Entities.Product instance = new Domain.Entities.Product(_productId, _qrCode, _name, _unitId, _categoryId, _brandId);

            // Act
            Action action = () => instance.ChangeBrand(Guid.Empty);

            // Asserts
            var exception = Assert.Throws<DomainExceptionValidation>(() => action());
            Assert.Equal(BRAND_ID_REQUIRED_MESSAGE, exception.Message);
        }

        [Fact]
        public void Change_product_name()
        {
            // Arrange 
            string newProductName = "Ojaldre";
            Domain.Entities.Product instance;
            instance = new Domain.Entities.Product(_productId, _qrCode, _name, _unitId, _categoryId, _brandId);

            // Act
            instance.ModifyProductName(newProductName);

            // Asserts
            Assert.NotNull(instance);
            Assert.Equal(instance.Id, _productId);
            Assert.Equal(instance.QRCode, _qrCode);
            Assert.Equal(instance.Name, newProductName);
            Assert.Equal(instance.UnitId, _unitId);
            Assert.Equal(instance.CategoryId, _categoryId);
            Assert.Equal(instance.BrandId, _brandId);
        }

        [Fact]
        public void Catch_exception_when_change_product_name_with_empty_value()
        {
            // Arrange 
            Domain.Entities.Product instance = new Domain.Entities.Product(_productId, _qrCode, _name, _unitId, _categoryId, _brandId);

            // Act
            Action action = () => instance.ModifyProductName(string.Empty);

            // Asserts
            var exception = Assert.Throws<DomainExceptionValidation>(() => action());
            Assert.Equal(NAME_NULL_OR_EMPTY_MESSAGE, exception.Message);
        }

        [Fact]
        public void Change_qrCode()
        {
            // Arrange 
            string newQrCode = "09090909";
            Domain.Entities.Product instance;
            instance = new Domain.Entities.Product(_productId, _qrCode, _name, _unitId, _categoryId, _brandId);

            // Act
            instance.ModifyQRCode(newQrCode);

            // Asserts
            Assert.NotNull(instance);
            Assert.Equal(instance.Id, _productId);
            Assert.Equal(instance.QRCode, newQrCode);
            Assert.Equal(instance.Name, _name);
            Assert.Equal(instance.UnitId, _unitId);
            Assert.Equal(instance.CategoryId, _categoryId);
            Assert.Equal(instance.BrandId, _brandId);
        }

        [Fact]
        public void Catch_exception_when_change_qrcode_with_empty_value()
        {
            // Arrange 
            Domain.Entities.Product instance = new Domain.Entities.Product(_productId, _qrCode, _name, _unitId, _categoryId, _brandId);

            // Act
            Action action = () => instance.ModifyQRCode(string.Empty);

            // Asserts
            var exception = Assert.Throws<DomainExceptionValidation>(() => action());
            Assert.Equal(QRCODE_NULL_OR_EMPTY_MESSAGE, exception.Message);
        }

        [Fact]
        public void Create_Product_instance()
        {
            // Arrange 
            Domain.Entities.Product instance;

            // Act
            instance = new Domain.Entities.Product(_productId, _qrCode, _name, _unitId, _categoryId, _brandId);

            // Asserts
            Assert.NotNull(instance);
            Assert.Equal(instance.Id, _productId);
            Assert.Equal(instance.QRCode, _qrCode);
            Assert.Equal(instance.Name, _name);
            Assert.Equal(instance.UnitId, _unitId);
            Assert.Equal(instance.CategoryId, _categoryId);
            Assert.Equal(instance.BrandId, _brandId);
        }

        [Fact]
        public void Catch_domailException_when_create_product_instance_with_name_empty()
        {
            // Arrange
            Action action = () => new Domain.Entities.Product(_productId, _qrCode, string.Empty, _unitId, _categoryId, _brandId);
            // Act
            var exception = Assert.Throws<DomainExceptionValidation>(() => action());
            // Asserts
            Assert.Equal(exception.Message, "name value is required");
        }

        [Fact]
        public void Catch_domailException_when_create_product_instance_with_qrCode_empty()
        {
            // Arrange
            Action action = () => new Domain.Entities.Product(_productId, string.Empty, _name, _unitId, _categoryId, _brandId);
            // Act
            var exception = Assert.Throws<DomainExceptionValidation>(() => action());
            // Asserts
            Assert.Equal(exception.Message, "qrCode value is required");
        }

        [Fact]
        public void Catch_domailException_when_create_product_instance_with_productId_empty()
        {
            // Arrange
            Action action = () => new Domain.Entities.Product(Guid.Empty, _qrCode, _name, _unitId, _categoryId, _brandId);
            // Act
            var exception = Assert.Throws<DomainExceptionValidation>(() => action());
            // Asserts
            Assert.Equal(exception.Message, "productId value is required");
        }

        [Fact]
        public void Catch_domailException_when_create_product_instance_with_unitId_empty()
        {
            // Arrange
            Action action = () => new Domain.Entities.Product(_productId, _qrCode, _name, Guid.Empty, _categoryId, _brandId);
            // Act
            var exception = Assert.Throws<DomainExceptionValidation>(() => action());
            // Asserts
            Assert.Equal(exception.Message, "unitId value is required");
        }

        [Fact]
        public void Catch_domailException_when_create_product_instance_with_categoryId_empty()
        {
            // Arrange
            Action action = () => new Domain.Entities.Product(_productId, _qrCode, _name, _unitId, Guid.Empty, _brandId);
            // Act
            var exception = Assert.Throws<DomainExceptionValidation>(() => action());
            // Asserts
            Assert.Equal(exception.Message, "categoryId value is required");
        }

        [Fact]
        public void Catch_domailException_when_create_product_instance_with_brandId_empty()
        {
            // Arrange
            Action action = () => new Domain.Entities.Product(_productId, _qrCode, _name, _unitId, _categoryId, Guid.Empty);
            // Act
            var exception = Assert.Throws<DomainExceptionValidation>(() => action());
            // Asserts
            Assert.Equal(exception.Message, "brandId value is required");
        }
    }
}
