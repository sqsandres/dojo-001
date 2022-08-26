namespace Dojo.Bakery.Transaction.Domain.Test;

public class BrandShould
{
    [Fact]
    public void Create_Brand_WithValidParameters()
    {
        var brand = new Brand("Haz de Oroz");
        Assert.IsNotType<DomainExceptionValidation>(brand);
    }

    [Fact]
    public void Create_Brand_Invalid_Name_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => new Brand(string.Empty));
        Assert.Equal("name value is required", domainException.Message);
    }

    [Fact]
    public void Update_Brand_Without_Exception()
    {
        var brand = new Brand("Haz de Oroz");
        brand.ChangeName("Harina doña pepa");
        Assert.IsNotType<DomainExceptionValidation>(brand);
    }
}
