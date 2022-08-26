using Dojo.Bakery.Inventory.Application.DTOs.Products;
using Dojo.Bakery.Inventory.Application.Queries.Products;
using Dojo.Bakery.Inventory.Domain.Entities;
using Dojo.Bakery.Inventory.Infra.DataContract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dojo.Bakery.Inventory.Application.Handlers.Products
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
    {
        private readonly ILogger<GetAllProductsQueryHandler> _logger;
        private readonly IProductRepository _productRepository;
        public GetAllProductsQueryHandler(ILogger<GetAllProductsQueryHandler> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }
        public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Product> query = from i in await _productRepository.GetEntitiesAsync()
                                         orderby i.Name
                                         select i;
            List<ProductDto> list = new List<ProductDto>();
            foreach (Product item in query.ToList())
            {
                list.Add(new ProductDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    QRCode = item.QRCode,
                    UnitId = item.UnitId,
                    CategoryId = item.CategoryId,
                    BrandId = item.BrandId
                });
            }
            return list;
        }
    }
}
