namespace Dojo.Bakery.Transaction.Domain.Test;

public class DocumentTypeShould
{
    [Fact]
    public void Create_DocumentType_WithValidParameters()
    {
        var documentType = new DocumentType("Lacteos");
        Assert.IsNotType<DomainExceptionValidation>(documentType);
    }

    [Fact]
    public void Create_DocumentType_Invalid_Name_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => new DocumentType(string.Empty));
        Assert.Equal("name value is required", domainException.Message);
    }

    [Fact]
    public void Update_DocumentType_Without_Exception()
    {
        var documentType = new DocumentType("C.C");
        documentType.ChangeName("CC");
        Assert.IsNotType<DomainExceptionValidation>(documentType);
        Assert.Equal("CC", documentType.Name);
    }
}
