namespace Dojo.Bakery.Transaction.Domain.Test.Fackes;

public class SaleFakeData
{
    public static Sell CreateValidSell
    {
        get { return new Sell("New Sell", "1234", 100000m, Guid.NewGuid()); }
    }

    public static Sell CreateSell_WithInvalidName
    {
        get { return new Sell(string.Empty, "1234", 100000m, Guid.NewGuid()); }
    }

    public static Sell CreateSell_WithInvalidNumber
    {
        get { return new Sell("New Sell", string.Empty, 100000m, Guid.NewGuid()); }
    }

    public static Sell CreateSell_WithInvalidTotal
    {
        get { return new Sell("New Sell", "1234", -800, Guid.NewGuid()); }
    }

    public static Sell CreateSell_WithInvalidClientId
    {
        get { return new Sell("New Sell", "1234", 100000m, Guid.Empty); }
    }

}
