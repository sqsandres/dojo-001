namespace Dojo.Bakery.Transaction.Domain.Test;

public class SaleShould
{
    [Fact]
    public void Create_Sale_WithValidParameters()
    {
        var sale = SaleFakeData.CreateValidSell;
        Assert.IsNotType<DomainExceptionValidation>(sale);
    }

    [Fact]
    public void Create_Sale_Invalid_Name_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => SaleFakeData.CreateSell_WithInvalidName);
        Assert.Equal("name value is required", domainException.Message);
    }

    [Fact]
    public void Create_Sale_Invalid_Number_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => SaleFakeData.CreateSell_WithInvalidNumber);
        Assert.Equal("number value is required", domainException.Message);
    }

    [Fact]
    public void Create_Sale_Invalid_Total_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => SaleFakeData.CreateSell_WithInvalidTotal);
        Assert.Equal("total value is required", domainException.Message);
    }

    [Fact]
    public void Create_Sale_Invalid_ClientId_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => SaleFakeData.CreateSell_WithInvalidClientId);
        Assert.Equal("clientId value is required", domainException.Message);
    }

    [Fact]
    public void Update_SaleName_Without_Exception()
    {
        var sell = SaleFakeData.CreateValidSell;
        sell.Update("Update Sell", "1234", 124.600m, Guid.NewGuid());
        Assert.IsNotType<DomainExceptionValidation>(sell);
        Assert.Equal("Update Sell", sell.Name);
    }
}
