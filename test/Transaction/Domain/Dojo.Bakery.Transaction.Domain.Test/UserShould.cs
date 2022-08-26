namespace Dojo.Bakery.Transaction.Domain.Test;

public class UserShould
{
    [Fact]
    public void Create_User_WithValidParameters()
    {
        var user = new User(Guid.NewGuid(), "Karla Sanchez");
        Assert.IsNotType<DomainExceptionValidation>(user);
    }

    [Fact]
    public void Create_User_Invalid_Name_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => new User(Guid.NewGuid(), string.Empty));
        Assert.Equal("name value is required", domainException.Message);
    }

    [Fact]
    public void Create_User_Invalid_Id_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => new User(Guid.Empty, "Karla Sanchez"));
        Assert.Equal("id value is required", domainException.Message);
    }

    [Fact]
    public void Update_UserName_Without_Exception()
    {
        var user = new User(Guid.NewGuid(), "Karla Sanchez");
        user.ChangeName("Karla Sanchez Galvez");
        Assert.IsNotType<DomainExceptionValidation>(user);
        Assert.Equal("Karla Sanchez Galvez", user.Name);
    }
}
