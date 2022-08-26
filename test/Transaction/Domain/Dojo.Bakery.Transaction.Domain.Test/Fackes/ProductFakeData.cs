namespace Dojo.Bakery.Transaction.Domain.Test.Fackes;

public class ProductFakeData
{
    public static Product CreateValidProduct
    {
        get
        {
            return new Product("Harina", 12, Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), "QR");
        }
    }
    public static Product CreateProduct_WithInvalidName
    {
        get
        {
            return new Product(string.Empty, 12, Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), "QR");
        }
    }

    public static Product CreateProduct_WithInvalidPrice
    {
        get
        {
            return new Product("Harina", -2000, Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), "QR");
        }
    }
    public static Product CreateProduct_WithInvaldUnitId
    {
        get
        {
            return new Product("Harina", 2000, Guid.Empty, Guid.NewGuid(), Guid.NewGuid(), "QR");
        }
    }
    public static Product CreateProduct_WithInvalidCategoryId
    {
        get
        {
            return new Product("Harina", -2000, Guid.NewGuid(), Guid.Empty, Guid.NewGuid(), "QR");
        }
    }
    public static Product CreateProduct_WithInvalidBrandId
    {
        get
        {
            return new Product("Harina", 2000, Guid.NewGuid(), Guid.NewGuid(), Guid.Empty, "QR");
        }
    }
    public static Product CreateProduct_WithInvalidQR
    {
        get
        {
            return new Product("Harina", 2000, Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), String.Empty);
        }
    }
}
