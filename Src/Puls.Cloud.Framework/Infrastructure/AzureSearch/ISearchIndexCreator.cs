using System.Collections.Generic;
using Azure.Search.Documents.Indexes.Models;
using Puls.Cloud.Framework.Application.Contracts;

namespace Puls.Cloud.Framework.Infrastructure.AzureSearch;

public interface ISearchIndexCreator<TRequest, out TResult>
    where TRequest : IUpdateSearchCommand<TResult>
{
    IEnumerable<SearchField> GetSearchFields();
}
