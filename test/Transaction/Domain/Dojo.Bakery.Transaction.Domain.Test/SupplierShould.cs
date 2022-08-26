namespace Dojo.Bakery.Transaction.Domain.Test;

public class SupplierShould
{
    [Fact]
    public void Create_Supplier_WithValidParameters()
    {
        var supplier = SuppliergFakeData.CreateValidSupplier;
        Assert.IsNotType<DomainExceptionValidation>(supplier);
    }

    [Fact]
    public void Create_Supplier_Invalid_Name_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => SuppliergFakeData.CreateSupplier_WithInvalidName);
        Assert.Equal("name value is required", domainException.Message);
    }

    [Fact]
    public void Create_Supplier_Invalid_DocumentId_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => SuppliergFakeData.CreateSupplier_WithInvalidDocumentId);
        Assert.Equal("documentId value is required", domainException.Message);
    }

    [Fact]
    public void Create_Supplier_Invalid_DocumentType_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => SuppliergFakeData.CreateSupplier_WithInvalidDocumentType);
        Assert.Equal("documentTypeId value is required", domainException.Message);
    }

    [Fact]
    public void Create_Supplier_Invalid_Address_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => SuppliergFakeData.CreateSupplier_WithInvalidAddress);
        Assert.Equal("address value is required", domainException.Message);
    }

    [Fact]
    public void Create_Supplier_Invalid_PhoneNumber_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => SuppliergFakeData.CreateSupplier_WithInvalidPhoneNumber);
        Assert.Equal("phoneNumber value is required", domainException.Message);
    }

    [Fact]
    public void Create_Supplier_Invalid_Email_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => SuppliergFakeData.CreateSupplier_WithInvalidEmail);
        Assert.Equal("email value is required", domainException.Message);
    }

    [Fact]
    public void Update_Supplier_Without_Exception()
    {
        var supplier = SuppliergFakeData.CreateValidSupplier;
        supplier.Update("Sandra Alvarez", "1060655493", Guid.NewGuid(), "5a Av Street", "305897654", "salvarez@test2.com");
        Assert.IsNotType<DomainExceptionValidation>(supplier);
    }
}
