namespace Dojo.Bakery.Transaction.Domain.Test;

public class CategoryShould
{
    [Fact]
    public void Create_Brand_WithValidParameters()
    {
        var category = new Category("Lacteos");
        Assert.IsNotType<DomainExceptionValidation>(category);
    }

    [Fact]
    public void Create_Brand_Invalid_Name_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => new Category(string.Empty));
        Assert.Equal("name value is required", domainException.Message);
    }

    [Fact]
    public void Update_Brand_Without_Exception()
    {
        var category = new Category("Lacteos");
        category.ChangeName("Lacteos Saludables");
        Assert.IsNotType<DomainExceptionValidation>(category);
        Assert.Equal("Lacteos Saludables", category.Name);
    }
}
