namespace Dojo.Bakery.Transaction.Application.Test.Fakes;

public class UnitFakeData
{
    public static List<Unit> GetUnit
    {
        get
        {
            return new List<Unit>()
            {
                new Unit("Pounds"),
                new Unit("Kgs"),
                new Unit("Tons")
            };
        }
    }
}
