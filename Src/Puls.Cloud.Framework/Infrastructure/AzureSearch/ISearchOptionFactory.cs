using Azure.Search.Documents;
using Puls.Cloud.Framework.Application.Contracts;

namespace Puls.Cloud.Framework.Infrastructure.AzureSearch;

public interface ISearchOptionFactory<TRequest, out TResult>
    where TRequest : ISearchQuery<TResult>
{
    SearchOptions Create(TRequest request);
}
