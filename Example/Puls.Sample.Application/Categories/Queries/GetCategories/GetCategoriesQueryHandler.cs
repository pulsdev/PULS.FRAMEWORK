using Puls.Sample.Application.Categories.Queries.Dto;
using Puls.Sample.Domain.Commons;
using Puls.Cloud.Framework.Application.Configuration.Queries;
using Puls.Cloud.Framework.Application.Contracts;
using Puls.Cloud.Framework.Cosmos.Abstractions;
using Microsoft.Azure.Cosmos;

namespace Puls.Sample.Application.Categories.Queries.GetCategories
{
    internal class GetCategoriesQueryHandler : IPageableQueryHandler<GetCategoriesQuery, CategoryQueryDto>
    {
        private readonly Container _container;

        public GetCategoriesQueryHandler(IContainerFactory factory)
        {
            _container = factory.Get(ServiceDatabaseContainers.Categories);
        }

        public async Task<PagedDto<CategoryQueryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var fromWhere = @$"FROM	categories";

            var sql = @$"SELECT * {fromWhere} ";

            var query = new QueryDefinition(sql);

            var publishedJobs = await _container.AsPagedAsync(request, query, fromWhere);

            return publishedJobs;
        }
    }
}