using Puls.Cloud.Framework.Application.Contracts;

namespace Puls.Cloud.Framework.Infrastructure.AzureSearch;

public interface IQueryFactory<TRequest>
    where TRequest : SearchQuery
{
    Query Create(TRequest request);
}
