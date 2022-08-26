using Dojo.Bakery.Inventory.Application.DTOs.Inventory;
using Dojo.Bakery.Inventory.Application.Queries.Inventory;
using Dojo.Bakery.Inventory.Infra.DataContract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dojo.Bakery.Inventory.Application.Handlers.Inventory
{
    public class GetAllInventoryQueryHandler : IRequestHandler<GetAllInventoryQuery, List<InventoryResponseDto>>
    {
        private readonly ILogger<GetAllInventoryQueryHandler> _logger;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IProductRepository _productRepository;

        public GetAllInventoryQueryHandler(ILogger<GetAllInventoryQueryHandler> logger, IInventoryRepository inventoryRepository, IProductRepository productRepository)
        {
            _logger = logger;
            _inventoryRepository = inventoryRepository;
            _productRepository = productRepository;
        }
        public async Task<List<InventoryResponseDto>> Handle(GetAllInventoryQuery request, CancellationToken cancellationToken)
        {
            var query = from i in await _inventoryRepository.GetEntitiesAsync()
                        select i;
            List<InventoryResponseDto> list = new List<InventoryResponseDto>();
            foreach (var item in query.ToList())
            {

                var inven = new InventoryResponseDto
                {
                    Id = item.Id,
                    Stock = item.Stock
                };

                var productDto = new DTOs.Products.ProductDto();
                var product = await _productRepository.GetByIdAsync(item.ProductId);
                productDto.Id = item.ProductId;
                productDto.CategoryId = product.CategoryId;
                productDto.QRCode = product.QRCode;
                productDto.Name = product.Name;
                productDto.BrandId = product.BrandId;
                productDto.UnitId = product.UnitId;
                
                inven.Product = productDto;
                list.Add(inven);
            }
            return list;
        }
    }
}
