namespace Dojo.Bakery.Transaction.Domain.Test.Fackes;

public class SuppliergFakeData
{
    public static Supplier CreateValidSupplier
    {
        get { return new Supplier("Sandra Alvarez", "1060655493", Guid.NewGuid(), "5 Av Street", "305897654", "salvarez@test.com"); }
    }

    public static Supplier CreateSupplier_WithInvalidName
    {
        get { return new Supplier(string.Empty, "1060655493", Guid.NewGuid(), "5 Av Street", "305897654", "salvarez@test.com"); }
    }
    public static Supplier CreateSupplier_WithInvalidDocumentId
    {
        get { return new Supplier("Sandra Alvarez", string.Empty, Guid.NewGuid(), "5 Av Street", "305897654", "salvarez@test.com"); }
    }

    public static Supplier CreateSupplier_WithInvalidDocumentType
    {
        get { return new Supplier("Sandra Alvarez", "1060655493", Guid.Empty, "5 Av Street", "305897654", "salvarez@test.com"); }
    }

    public static Supplier CreateSupplier_WithInvalidAddress
    {
        get { return new Supplier("Sandra Alvarez", "1060655493", Guid.NewGuid(), string.Empty, "305897654", "salvarez@test.com"); }
    }

    public static Supplier CreateSupplier_WithInvalidPhoneNumber
    {
        get { return new Supplier("Sandra Alvarez", "1060655493", Guid.NewGuid(), "5 Av Street", string.Empty, "salvarez@test.com"); }
    }
    public static Supplier CreateSupplier_WithInvalidEmail
    {
        get { return new Supplier("Sandra Alvarez", "1060655493", Guid.NewGuid(), "5 Av Street", "305897654", string.Empty); }
    }
}
