using Dojo.Bakery.BuildingBlocks.Commons;
using Dojo.Bakery.BuildingBlocks.Commons.Repositories;
using Dojo.Bakery.Inventory.Application.Commands.Products;
using Dojo.Bakery.Inventory.Infra.DataContract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dojo.Bakery.Inventory.Application.Handlers.Products
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Guid>
    {
        private readonly ILogger<UpdateProductCommandHandler> _logger;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(ILogger<UpdateProductCommandHandler> logger, IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            DomainExceptionValidation.When(request == null, "The product Id and product data are required");
            DomainExceptionValidation.When(request.ProductId == Guid.Empty, "The product Id is required");
            DomainExceptionValidation.When(request.Item == null, "The product data is required");

            Domain.Entities.Product obj = await _productRepository.GetByIdAsync(request.ProductId);
            DomainExceptionValidation.When(obj == null, $"{request.ProductId}: Product didn't find");
            obj.ModifyProductName(request.Item.Name);
            obj.ModifyQRCode(request.Item.QRCode);
            obj.ChangeBrand(request.Item.BrandId);
            obj.ChangeUnit(request.Item.UnitId);
            obj.ChangeCategory(obj.CategoryId);

            await _unitOfWork.CommitAsync();
            return obj.Id;
        }
    }
}
