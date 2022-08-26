namespace Dojo.Bakery.Transaction.Application.Test.Fakes;

public class BrandFakeData
{
    public static IEnumerable<Brand> GetBrands
    {
        get
        {
            return new List<Brand>()
            {
                new Brand ("Celema"),
                new Brand ("Harina Manuelita")
            };
        }
    }
}
