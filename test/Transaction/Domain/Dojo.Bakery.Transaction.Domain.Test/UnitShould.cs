namespace Dojo.Bakery.Transaction.Domain.Test;

public class UnitShould
{
    [Fact]
    public void Create_Unit_WithValidParameters()
    {
        var unit = new Unit("Pounds");
        Assert.IsNotType<DomainExceptionValidation>(unit);
    }

    [Fact]
    public void Create_Unit_Invalid_Name_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => new Unit(string.Empty));
        Assert.Equal("name value is required", domainException.Message);
    }

    [Fact]
    public void Update_Unit_Without_Exception()
    {
        var unit = new Unit("Pounds");
        unit.ChangeName("Kilograms");
        Assert.IsNotType<DomainExceptionValidation>(unit);
        Assert.Equal("Kilograms", unit.Name);
    }
}
