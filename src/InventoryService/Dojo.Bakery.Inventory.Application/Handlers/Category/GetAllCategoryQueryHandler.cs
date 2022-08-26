using Dojo.Bakery.Inventory.Application.DTOs.Category;
using Dojo.Bakery.Inventory.Application.Queries.Category;
using Dojo.Bakery.Inventory.Infra.DataContract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dojo.Bakery.Inventory.Application.Handlers.Category
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<CategoryDto>>
    {
        private readonly ILogger<GetAllCategoryQueryHandler> _logger;
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoryQueryHandler(ILogger<GetAllCategoryQueryHandler> logger, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public async Task<List<CategoryDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Domain.Category> query = from i in await _categoryRepository.GetEntitiesAsync()
                                                 orderby i.Name
                                                 select i;
            List<CategoryDto> list = new List<CategoryDto>();
            foreach (Domain.Category item in query.ToList())
            {
                list.Add(new CategoryDto()
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }
            return list;
        }
    }
}
