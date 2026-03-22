using Azure.Search.Documents.Indexes;

namespace Puls.Cloud.Framework.Infrastructure.AzureSearch;

public interface ISearchIndexClientFactory
{
    SearchIndexClient Create();
}
