namespace Dojo.Bakery.Transaction.Domain.Test;

public class OrderDetailShould
{
    [Fact]
    public void Create_OrderDetail_WithValidParameters()
    {
        var orderDetail = OrderDetailFakeData.CreateValidOrderDetail;
        Assert.IsNotType<DomainExceptionValidation>(orderDetail);
    }

    [Fact]
    public void Create_Order_Invalid_OrderId_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => OrderDetailFakeData.CreateOrderDetail_WithInvalidOrderId);
        Assert.Equal("Invalid orderId. orderId is required", domainException.Message);
    }

    [Fact]
    public void Create_Order_Invalid_ProductId_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => OrderDetailFakeData.CreateOrderDetail_WithInvalidProductId);
        Assert.Equal("Invalid producId. producId is required", domainException.Message);
    }

    [Fact]
    public void Create_Order_Invalid_Quantity_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => OrderDetailFakeData.CreateOrderDetail_WithInvalidQuantity);
        Assert.Equal("Invalid quantity. The quantity must be greater than 0", domainException.Message);
    }
    [Fact]
    public void Create_Order_Invalid_UnitPrice_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => OrderDetailFakeData.CreateOrderDetail_WithInvalidUnitPrice);
        Assert.Equal("Invalid quantity. The quantity must be greater than 0", domainException.Message);
    }
}
