using Dojo.Bakery.Transaction.Application.DTOs.Products;

namespace Dojo.Bakery.Transaction.Application.Test.Fakes;

public class ProductFakeData
{
    public static ProductDto GetProduct
    {
        get 
        {
            return new ProductDto()
            {
                Name = "Leche",
                UnitPrice = 1200,
                UnitId = Guid.NewGuid(),
                CategoryId = Guid.NewGuid(),
                BrandI = Guid.NewGuid(),
                QR = "leche.jpg"
            };
        }
    }

    public static ProductDto GetInvalidProductName
    {
        get
        {
            return new ProductDto()
            {
                Name = string.Empty,
                UnitPrice = 1200,
                UnitId = Guid.NewGuid(),
                CategoryId = Guid.NewGuid(),
                BrandI = Guid.NewGuid(),
                QR = "leche.jpg"
            };
        }
    }
    public static ProductDto GetInvalidProductUnitPrice
    {
        get
        {
            return new ProductDto()
            {
                Name = "Leche",
                UnitPrice = -1200,
                UnitId = Guid.NewGuid(),
                CategoryId = Guid.NewGuid(),
                BrandI = Guid.NewGuid(),
                QR = "leche.jpg"
            };
        }
    }

    public static ProductDto GetInvalidProductUnitId
    {
        get
        {
            return new ProductDto()
            {
                Name = "Leche",
                UnitPrice = -1200,
                UnitId = Guid.Empty,
                CategoryId = Guid.NewGuid(),
                BrandI = Guid.NewGuid(),
                QR = "leche.jpg"
            };
        }
    }

    public static IEnumerable<ProductDto> GetProductsDto
    {
        get
        {
            return new List<ProductDto>()
            {
                new ProductDto()
                {
                    BrandI = Guid.NewGuid(),
                    CategoryId = Guid.NewGuid(),
                    Name = "Leche",
                    UnitId = Guid.NewGuid(),
                    UnitPrice = 1200,
                    QR = "leche.jpg"
                },
                new ProductDto()
                {
                    BrandI = Guid.NewGuid(),
                    CategoryId = Guid.NewGuid(),
                    Name = "Harina",
                    UnitId = Guid.NewGuid(),
                    UnitPrice = 1200,
                    QR = "harina.jpg"
                },
            };
        }
    }

    public static IEnumerable<Product> GetProducts
    {
        get
        {
            return new List<Product>()
            {
                new Product("Leche", 1040, Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), "leche.jpg"),
                new Product("Harian", 1000, Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), "harina.jpg"),
                new Product("Mantequilla", 1120, Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), "mante.jpg")
            };
        }
    }
}
