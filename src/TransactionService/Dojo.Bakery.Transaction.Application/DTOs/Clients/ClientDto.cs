namespace Dojo.Bakery.Transaction.Application.DTOs.Clients;

public class ClientDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Documento { get; set; }

    public Guid DocumentTypeId { get; set; }

    public string Address { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }
}
