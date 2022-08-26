using Dojo.Bakery.BuildingBlocks.Commons;
using Dojo.Bakery.BuildingBlocks.Commons.Repositories;
using Dojo.Bakery.Inventory.Application.Commands.Products;
using Dojo.Bakery.Inventory.Domain.Entities;
using Dojo.Bakery.Inventory.Infra.DataContract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dojo.Bakery.Inventory.Application.Handlers.Products
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly ILogger<CreateProductCommandHandler> _logger;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateProductCommandHandler(ILogger<CreateProductCommandHandler> logger, IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            DomainExceptionValidation.When(request == null || request.Item == null, "Creation data is required");
            Product product = new Product(request.Item.Id, request.Item.QRCode,request.Item.Name, request.Item.UnitId, request.Item.CategoryId, request.Item.BrandId);
            await _productRepository.CreateAsync(product);
            await _unitOfWork.CommitAsync();
            return product.Id;
        }
    }
}
