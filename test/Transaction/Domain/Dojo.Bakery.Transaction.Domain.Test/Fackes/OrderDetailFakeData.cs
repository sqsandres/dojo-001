namespace Dojo.Bakery.Transaction.Domain.Test.Fackes;

public class OrderDetailFakeData
{
    public static OrderDetail CreateValidOrderDetail
    {
        get { return new OrderDetail(Guid.NewGuid(), Guid.NewGuid(),2, 1200); }
    }
    
    public static OrderDetail CreateOrderDetail_WithInvalidOrderId
    {
        get { return new OrderDetail(Guid.Empty, Guid.NewGuid(), 2, 1200); }
    }
    public static OrderDetail CreateOrderDetail_WithInvalidProductId
    {
        get { return new OrderDetail(Guid.NewGuid(), Guid.Empty, 2, 1200); }
    }
    public static OrderDetail CreateOrderDetail_WithInvalidQuantity
    {
        get { return new OrderDetail(Guid.NewGuid(), Guid.NewGuid(), -2, 1200); }
    }
    public static OrderDetail CreateOrderDetail_WithInvalidUnitPrice
    {
        get { return new OrderDetail(Guid.NewGuid(), Guid.NewGuid(), 2, -1200); }
    }
}
