namespace Dojo.Bakery.Transaction.Domain.Test;

public class StoreShould
{
    public void SetUp()
    {

    }

    [Fact]
    public void Create_Store_WithValidParameters()
    {
        var store = StoreFakeData.CreateValidStore;
        Assert.IsNotType<DomainExceptionValidation>(store);
    }

    [Fact]
    public void Create_Store_Invalid_Name_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => StoreFakeData.CreateStore_WithInvalidName);
        Assert.Equal("name value is required", domainException.Message);
    }

    [Fact]
    public void Create_Store_Invalid_Address_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => StoreFakeData.CreateStore_WithInvalidAddress);
        Assert.Equal("address value is required", domainException.Message);
    }

    [Fact]
    public void Create_Store_Invalid_PhoneNUmber_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => StoreFakeData.CreateStore_WithInvalidPhone);
        Assert.Equal("phone value is required", domainException.Message);
    }

    [Fact]
    public void Create_Store_Invalid_City_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => StoreFakeData.CreateStore_WithInvalidCity);
        Assert.Equal("city value is required", domainException.Message);
    }

    [Fact]
    public void Create_Store_Invalid_Email_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => StoreFakeData.CreateStore_WithInvalidEmail);
        Assert.Equal("email value is required", domainException.Message);
    }

    [Fact]
    public void Create_Store_Invalid_Country_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => StoreFakeData.CreateStore_WithInvalidCountry);
        Assert.Equal("country value is required", domainException.Message);
    }

    [Fact]
    public void Create_Store_Invalid_DocumentNumber_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => StoreFakeData.CreateStore_WithInvalidDocumentNumber);
        Assert.Equal("documentNumber value is required", domainException.Message);
    }

    [Fact]
    public void Create_Store_Invalid_OpenCloseTime_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => StoreFakeData.CreateStore_WithInvalidOpenCloseTime);
        Assert.Equal("Close and Open Time are incorrect", domainException.Message);
    }
    #region Update

    [Fact]
    public void Update_StoreName_Without_Exception()
    {
        var store = StoreFakeData.CreateValidStore;
        store.ChangeName("Victoria Plaza");
        Assert.IsNotType<DomainExceptionValidation>(store);
        Assert.Equal("Victoria Plaza", store.Name);
    }

    [Fact]
    public void Update_StoreAddress_Without_Exception()
    {
        var store = StoreFakeData.CreateValidStore;
        store.ChangeAddress("Carrera 65b esquina");
        Assert.IsNotType<DomainExceptionValidation>(store);
        Assert.Equal("Carrera 65b esquina", store.Address);
    }

    [Fact]
    public void Update_StorePhone_Without_Exception()
    {
        var store = StoreFakeData.CreateValidStore;
        store.ChangePhone("324987654");
        Assert.IsNotType<DomainExceptionValidation>(store);
        Assert.Equal("324987654", store.Phone);
    }

    [Fact]
    public void Update_StoreCity_Without_Exception()
    {
        var store = StoreFakeData.CreateValidStore;
        store.ChangeCity("Medellin");
        Assert.IsNotType<DomainExceptionValidation>(store);
        Assert.Equal("Medellin", store.City);
    }

    [Fact]
    public void Update_StoreEmail_Without_Exception()
    {
        var store = StoreFakeData.CreateValidStore;
        store.ChangeEmail("vplaza@test.com");
        Assert.IsNotType<DomainExceptionValidation>(store);
        Assert.Equal("vplaza@test.com", store.Email);
    }

    [Fact]
    public void Update_StoreCountry_Without_Exception()
    {
        var store = StoreFakeData.CreateValidStore;
        store.ChangeCountry("Brazil");
        Assert.IsNotType<DomainExceptionValidation>(store);
        Assert.Equal("Brazil", store.Country);
    }

    [Fact]
    public void Update_StoreDocumentNumber_Without_Exception()
    {
        var store = StoreFakeData.CreateValidStore;
        store.ChangeDocumentNumber("9001245");
        Assert.IsNotType<DomainExceptionValidation>(store);
        Assert.Equal("9001245", store.DocumentNumber);
    }

    [Fact]
    public void Update_StoreOpenCloseTime_Without_Exception()
    {
        var store = StoreFakeData.CreateValidStore;
        store.ChangeOpenCloseTime(new TimeSpan(7, 00, 00), new TimeSpan(16, 00, 00));
        Assert.IsNotType<DomainExceptionValidation>(store);
        Assert.True(store.OpenTime < store.CloseTime);
    }

    #endregion

}
