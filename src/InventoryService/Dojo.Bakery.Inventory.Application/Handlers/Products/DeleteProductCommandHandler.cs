using Dojo.Bakery.BuildingBlocks.Commons;
using Dojo.Bakery.BuildingBlocks.Commons.Repositories;
using Dojo.Bakery.Inventory.Application.Commands.Products;
using Dojo.Bakery.Inventory.Infra.DataContract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dojo.Bakery.Inventory.Application.Handlers.Products
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Guid>
    {
        private readonly ILogger<DeleteProductCommandHandler> _logger;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(ILogger<DeleteProductCommandHandler> logger, IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            DomainExceptionValidation.When(request.ProductId == Guid.Empty, "The product id is required");
            await _productRepository.RemoveEntityAsync(request.ProductId);
            await _unitOfWork.CommitAsync();
            return Guid.Empty;
        }
    }
}
