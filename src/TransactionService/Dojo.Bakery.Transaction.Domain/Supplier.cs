namespace Dojo.Bakery.Transaction.Domain;

public class Supplier : AggregateRoot
{
    public string Name { get; private set; }
    public string DocumentId { get; private set; }

    public Guid DocumentTypeId { get; private set; }

    public string Address { get; private set; }

    public string PhoneNumber { get; private set; }

    public string Email { get; private set; }

    private Supplier() { }

    public Supplier(string name, string documentId, Guid documentType, string address, string phoneNumber, string email)
    {
        ValidateDomain(name, documentId, documentType, address, phoneNumber, email);
        Id = IdentityGenerator.NewSequentialGuid();        
    }

    public void Update(string name, string documentId, Guid documentType, string address, string phoneNumber, string email)
    {
        ValidateDomain(name, documentId, documentType, address, phoneNumber, email);
    }
    private void ValidateDomain(string name, string documentId, Guid documentTypeId, string address, string phoneNumber, string email)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), DomainExceptionValidation.RequiredValueMessage,nameof(name));
        DomainExceptionValidation.When(string.IsNullOrEmpty(documentId), DomainExceptionValidation.RequiredValueMessage,nameof(documentId));
        DomainExceptionValidation.When(documentTypeId == Guid.Empty, DomainExceptionValidation.RequiredValueMessage,nameof(documentTypeId));
        DomainExceptionValidation.When(string.IsNullOrEmpty(address), DomainExceptionValidation.RequiredValueMessage,nameof(address));
        DomainExceptionValidation.When(string.IsNullOrEmpty(phoneNumber), DomainExceptionValidation.RequiredValueMessage,nameof(phoneNumber));
        DomainExceptionValidation.When(string.IsNullOrEmpty(email), DomainExceptionValidation.RequiredValueMessage,nameof(email));

        Name = name;
        DocumentId = documentId;
        DocumentTypeId = documentTypeId;
        Address = address;
        PhoneNumber = phoneNumber;
        Email = email;
    }
}
