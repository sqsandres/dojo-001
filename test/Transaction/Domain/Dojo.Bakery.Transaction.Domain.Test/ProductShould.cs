
namespace Dojo.Bakery.Transaction.Domain.Test;

public class ProductShould
{
    [Fact]
    public void Create_Product_WithValidParameters()
    {        
        var product  = ProductFakeData.CreateValidProduct;
        Assert.IsNotType<DomainExceptionValidation>(product);
    }

    [Fact]
    public void Create_Product_Invalid_Name_DomainExceptionValidation()
    {        
        var domainException = Assert.Throws<DomainExceptionValidation>(() => ProductFakeData.CreateProduct_WithInvalidName);
        Assert.Equal("name value is required", domainException.Message);
    }

    [Fact]
    public void Create_Product_Invalid_Price_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => ProductFakeData.CreateProduct_WithInvalidPrice);
        Assert.Equal("unitPrice value is required", domainException.Message);
    }

    [Fact]
    public void Create_Product_Invalid_UnitId_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => ProductFakeData.CreateProduct_WithInvaldUnitId);
        Assert.Equal("unitId value is required", domainException.Message);
    }

    [Fact]
    public void Create_Product_Invalid_CategoryId_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => ProductFakeData.CreateProduct_WithInvalidCategoryId);
        Assert.Equal("categoryId value is required", domainException.Message);
    }

    [Fact]
    public void Create_Product_Invalid_BrandId_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => ProductFakeData.CreateProduct_WithInvalidBrandId);
        Assert.Equal("brandId value is required", domainException.Message);
    }

    [Fact]
    public void Create_Product_Invalid_QR_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => ProductFakeData.CreateProduct_WithInvalidQR);
        Assert.Equal("qr value is required", domainException.Message);
    }

    [Fact]
    public void Update_Product_Without_Exception()
    {
        var product = ProductFakeData.CreateValidProduct;
        product.Update("Harina", 12.9m, Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), "New QR");
        Assert.IsNotType<DomainExceptionValidation>(product);
    }
}
