namespace Dojo.Bakery.Transaction.Domain.Test.Fackes;

public class ClientFakeData
{
    public static Client CreateValidClient
    {
        get { return new Client("Camilo Sanchez", "1060655498", Guid.NewGuid(), "5 Av Street", "305897654", "csanchez@test.com"); }
    }

    public static Client CreateClient_WithInvalidName
    {
        get { return new Client(string.Empty, "1060655498", Guid.NewGuid(), "5 Av Street", "305897654", "csanchez@test.com"); }
    }
    public static Client CreateClient_WithInvalidDocumentId
    {
        get { return new Client("Camilo Sanchez", string.Empty, Guid.NewGuid(), "5 Av Street", "305897654", "csanchez@test.com"); }
    }

    public static Client CreateClient_WithInvalidDocumentType
    {
        get { return new Client("Camilo Sanchez", "1060655498", Guid.Empty, "5 Av Street", "305897654", "csanchez@test.com"); }
    }

    public static Client CreateClient_WithInvalidAddress
    {
        get { return new Client("Camilo Sanchez", "1060655498", Guid.NewGuid(), string.Empty, "305897654", "csanchez@test.com"); }
    }

    public static Client CreateClient_WithInvalidPhoneNumber
    {
        get { return new Client("Camilo Sanchez", "1060655498", Guid.NewGuid(), "5 Av Street", string.Empty, "csanchez@test.com"); }
    }
    public static Client CreateClient_WithInvalidEmail
    {
        get { return new Client("Camilo Sanchez", "1060655498", Guid.NewGuid(), "5 Av Street", "305897654", string.Empty); }
    }
}
