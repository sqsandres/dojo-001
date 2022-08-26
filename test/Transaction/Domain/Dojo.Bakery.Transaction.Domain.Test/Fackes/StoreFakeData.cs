namespace Dojo.Bakery.Transaction.Domain.Test.Fackes;

public class StoreFakeData
{
    public static Store CreateValidStore
    {
        get { return new Store("Sede Chapinero", "Calle 56a", "33344455","Bogota", "chapinero@test.com", "Colombia", "9001234", 
            new TimeSpan(8, 00, 00), new TimeSpan(17, 00, 00)); }
    }

    public static Store CreateStore_WithInvalidName
    {
        get
        {
            return new Store(string.Empty, "Calle 56a", "33344455", "Bogota", "chapinero@test.com", "Colombia", "9001234",
            new TimeSpan(8, 00, 00), new TimeSpan(17, 00, 00));
        }
    }
    public static Store CreateStore_WithInvalidAddress
    {
        get
        {
            return new Store("Sede Chapinero", string.Empty, "33344455", "Bogota", "chapinero@test.com", "Colombia", "9001234",
            new TimeSpan(8, 00, 00), new TimeSpan(17, 00, 00));
        }
    }

    public static Store CreateStore_WithInvalidPhone
    {
        get
        {
            return new Store("Sede Chapinero", "Calle 56a", string.Empty, "Bogota", "chapinero@test.com", "Colombia", "9001234",
            new TimeSpan(8, 00, 00), new TimeSpan(17, 00, 00));
        }
    }

    public static Store CreateStore_WithInvalidCity
    {
        get
        {
            return new Store("Sede Chapinero", "Calle 56a", "33344455", string.Empty, "chapinero@test.com", "Colombia", "9001234",
            new TimeSpan(8, 00, 00), new TimeSpan(17, 00, 00));
        }
    }

    public static Store CreateStore_WithInvalidEmail
    {
        get
        {
            return new Store("Sede Chapinero", "Calle 56a", "33344455", "Bogota", string.Empty, "Colombia", "9001234",
            new TimeSpan(8, 00, 00), new TimeSpan(17, 00, 00));
        }
    }

    public static Store CreateStore_WithInvalidCountry
    {
        get
        {
            return new Store("Sede Chapinero", "Calle 56a", "33344455", "Bogota", "chapinero@test.com", string.Empty, "9001234",
            new TimeSpan(8, 00, 00), new TimeSpan(17, 00, 00));
        }
    }

    public static Store CreateStore_WithInvalidDocumentNumber
    {
        get
        {
            return new Store("Sede Chapinero", "Calle 56a", "33344455", "Bogota", "chapinero@test.com", "Colombia", string.Empty,
            new TimeSpan(8, 00, 00), new TimeSpan(17, 00, 00));
        }
    }

    public static Store CreateStore_WithInvalidOpenCloseTime
    {
        get
        {
            return new Store("Sede Chapinero", "Calle 56a", "33344455", "Bogota", "chapinero@test.com", "Colombia", "9001234",
            new TimeSpan(17, 00, 00), new TimeSpan(8, 00, 00));
        }
    }
}
