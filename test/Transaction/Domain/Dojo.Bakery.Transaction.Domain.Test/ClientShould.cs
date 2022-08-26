namespace Dojo.Bakery.Transaction.Domain.Test;

public class ClientShould
{
    [Fact]
    public void Create_Client_WithValidParameters()
    {
        var supplier = ClientFakeData.CreateValidClient;
        Assert.IsNotType<DomainExceptionValidation>(supplier);
    }

    [Fact]
    public void Create_Client_Invalid_Name_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => ClientFakeData.CreateClient_WithInvalidName);
        Assert.Equal("name value is required", domainException.Message);
    }

    [Fact]
    public void Create_Client_Invalid_DocumentId_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => ClientFakeData.CreateClient_WithInvalidDocumentId);
        Assert.Equal("documentId value is required", domainException.Message);
    }

    [Fact]
    public void Create_Client_Invalid_DocumentType_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => ClientFakeData.CreateClient_WithInvalidDocumentType);
        Assert.Equal("documentTypeId value is required", domainException.Message);
    }

    [Fact]
    public void Create_Client_Invalid_Address_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => ClientFakeData.CreateClient_WithInvalidAddress);
        Assert.Equal("address value is required", domainException.Message);
    }

    [Fact]
    public void Create_Client_Invalid_PhoneNumber_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => ClientFakeData.CreateClient_WithInvalidPhoneNumber);
        Assert.Equal("phoneNumber value is required", domainException.Message);
    }

    [Fact]
    public void Create_Client_Invalid_Email_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => ClientFakeData.CreateClient_WithInvalidEmail);
        Assert.Equal("email value is required", domainException.Message);
    }

    [Fact]
    public void Update_Client_Without_Exception()
    {
        var supplier = SuppliergFakeData.CreateValidSupplier;
        supplier.Update("Camilo Sanchez", "1060655498", Guid.NewGuid(), "5a Av Street", "305897654", "csanchezg@test.com");
        Assert.IsNotType<DomainExceptionValidation>(supplier);
        Assert.Equal("csanchezg@test.com", supplier.Email);
        Assert.Equal("5a Av Street", supplier.Address);
    }
}
