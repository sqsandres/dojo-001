namespace Dojo.Bakery.Transaction.Domain.Test.Fackes;

public class OrderFakeData
{
    public static Order CreateValidOrder
    {
        get { return new Order(Guid.NewGuid(), 22.9m, "987", new DateTime(2022, 1, 1)); }
    }

    public static Order CreateOrder_WithInvalidVendorId
    {
        get { return new Order(Guid.Empty, 22.9m, "987", new DateTime(2022, 1, 1)); }
    }
    public static Order CreateOrder_WithInvalidTotal
    {
        get { return new Order(Guid.NewGuid(), -22.9m, "987", new DateTime(2022, 1, 1)); }
    }

    public static Order CreateOrder_WithInvalidInvoiceNumber
    {
        get { return new Order(Guid.NewGuid(), 22.9m, string.Empty, new DateTime(2022, 1, 1)); }
    }    
}
