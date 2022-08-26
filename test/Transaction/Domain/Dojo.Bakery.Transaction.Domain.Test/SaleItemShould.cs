namespace Dojo.Bakery.Transaction.Domain.Test;

public class SaleItemShould
{
    [Fact]
    public void Create_SaleItem_WithValidParameters()
    {
        var saleItem = SaleItemFakeData.CreateValidSellItem;
        Assert.IsNotType<DomainExceptionValidation>(saleItem);
    }

    [Fact]
    public void Create_SaleItem_Invalid_Name_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => SaleItemFakeData.CreateSell_WithInvalidName);
        Assert.Equal("name value is required", domainException.Message);
    }

    [Fact]
    public void Create_SaleItem_Invalid_SaleId_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => SaleItemFakeData.CreateSell_WithInvalidSaleId);
        Assert.Equal("sellId value is required", domainException.Message);
    }

    [Fact]
    public void Create_SaleItem_Invalid_ProductId_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => SaleItemFakeData.CreateSell_WithInvalidProductId);
        Assert.Equal("productId value is required", domainException.Message);
    }

    [Fact]
    public void Create_SaleItem_Invalid_Quantity_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => SaleItemFakeData.CreateSell_WithInvalidQuantity);
        Assert.Equal("quantity value is required", domainException.Message);
    }

    [Fact]
    public void Create_SaleItem_Invalid_UnitPrice_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => SaleItemFakeData.CreateSell_WithInvalidUnitPrice);
        Assert.Equal("unitPrice value is required", domainException.Message);
    }

    [Fact]
    public void Update_Brand_Without_Exception()
    {
        var saleItem = SaleItemFakeData.CreateValidSellItem;
        saleItem.Update("Harina", Guid.NewGuid(), Guid.NewGuid(), 43, 1150);
        Assert.IsNotType<DomainExceptionValidation>(saleItem);
        Assert.Equal(43, saleItem.Quantity);
    }
}
