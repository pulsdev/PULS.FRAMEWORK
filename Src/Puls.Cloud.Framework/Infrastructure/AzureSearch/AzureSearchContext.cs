using Azure.Search.Documents.Models;

namespace Puls.Cloud.Framework.Infrastructure.AzureSearch;

public class AzureSearchContext
{
    public SearchResults<SearchDocument> SearchResults { get; internal set; }
    public object QueryResult { get; internal set; }
}
