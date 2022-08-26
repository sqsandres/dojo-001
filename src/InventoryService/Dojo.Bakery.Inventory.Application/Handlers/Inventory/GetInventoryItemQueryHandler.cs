using Dojo.Bakery.BuildingBlocks.Commons;
using Dojo.Bakery.Inventory.Application.DTOs.Inventory;
using Dojo.Bakery.Inventory.Application.Queries.Inventory;
using Dojo.Bakery.Inventory.Infra.DataContract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dojo.Bakery.Inventory.Application.Handlers.Inventory
{

    internal class GetInventoryItemQueryHandler : IRequestHandler<GetInventoryItemQuery, InventoryResponseDto>
    {
        private readonly ILogger<GetInventoryItemQueryHandler> _logger;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IProductRepository _productRepository;

        public GetInventoryItemQueryHandler(ILogger<GetInventoryItemQueryHandler> logger, IInventoryRepository inventoryRepository, IProductRepository productRepository)
        {
            _logger = logger;
            _inventoryRepository = inventoryRepository;
            _productRepository = productRepository;
        }

        public async Task<InventoryResponseDto> Handle(GetInventoryItemQuery request, CancellationToken cancellationToken)
        {
            var query = await _inventoryRepository.GetByIdAsync(request.InventoryId);

            DomainExceptionValidation.When(query == null, $"{request.InventoryId}: Inventory item didn't find");

            InventoryResponseDto dto = new();
            dto.Id = request.InventoryId;
            dto.Stock = query.Stock;

            var product = await _productRepository.GetByIdAsync(query.ProductId);
            var productDto = new DTOs.Products.ProductDto();
            productDto.Id = query.ProductId;
            productDto.CategoryId = product.CategoryId;
            productDto.QRCode = product.QRCode;
            productDto.Name = product.Name;
            productDto.BrandId = product.BrandId;
            productDto.UnitId = product.UnitId;

            dto.Product = productDto;

            return dto;
        }
    }
}
