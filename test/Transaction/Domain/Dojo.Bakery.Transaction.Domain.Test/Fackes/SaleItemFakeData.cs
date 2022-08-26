namespace Dojo.Bakery.Transaction.Domain.Test.Fackes;

public class SaleItemFakeData
{
    public static SaleItem CreateValidSellItem
    {
        get { return new SaleItem("Harina", Guid.NewGuid(), Guid.NewGuid(), 54, 1250) ; }
    }

    public static SaleItem CreateSell_WithInvalidName
    {
        get { return new SaleItem(string.Empty, Guid.NewGuid(), Guid.NewGuid(), 54, 1250); }
    }

    public static SaleItem CreateSell_WithInvalidSaleId
    {
        get { return new SaleItem("Harina", Guid.Empty, Guid.NewGuid(), 54, 1250); }
    }

    public static SaleItem CreateSell_WithInvalidProductId
    {
        get { return new SaleItem("Harina", Guid.NewGuid(), Guid.Empty, 54, 1250); }
    }

    public static SaleItem CreateSell_WithInvalidQuantity
    {
        get { return new SaleItem("Harina", Guid.NewGuid(), Guid.NewGuid(), -1, 1250); }
    }

    public static SaleItem CreateSell_WithInvalidUnitPrice
    {
        get { return new SaleItem("Harina", Guid.NewGuid(), Guid.NewGuid(), 54, -1250); }
    }
}
