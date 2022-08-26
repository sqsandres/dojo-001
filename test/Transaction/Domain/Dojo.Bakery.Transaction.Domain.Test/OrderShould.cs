namespace Dojo.Bakery.Transaction.Domain.Test;

public class OrderShould
{
    [Fact]
    public void Create_Order_WithValidParameters()
    {
        var order = OrderFakeData.CreateValidOrder;
        Assert.IsNotType<DomainExceptionValidation>(order);
    }

    [Fact]
    public void Create_Order_Invalid_VendorId_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => OrderFakeData.CreateOrder_WithInvalidVendorId);
        Assert.Equal("vendorId value is required", domainException.Message);
    }

    [Fact]
    public void Create_Client_Invalid_Total_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => OrderFakeData.CreateOrder_WithInvalidTotal);
        Assert.Equal("Invalid total. The total must be greater than 0", domainException.Message);
    }

    [Fact]
    public void Create_Client_Invalid_InvoiceNumber_DomainExceptionValidation()
    {
        var domainException = Assert.Throws<DomainExceptionValidation>(() => OrderFakeData.CreateOrder_WithInvalidInvoiceNumber);
        Assert.Equal("invoiceNumber value is required", domainException.Message);
    }

    [Fact]
    public void Update_OrderInvoiceNumber_Without_Exception()
    {
        var order = OrderFakeData.CreateValidOrder;
        order.Updated(Guid.NewGuid(), 22.9m, "9870", new DateTime(2022, 1, 1));
        Assert.IsNotType<DomainExceptionValidation>(order);
        Assert.Equal("9870", order.InvoiceNumber);
    }
}
