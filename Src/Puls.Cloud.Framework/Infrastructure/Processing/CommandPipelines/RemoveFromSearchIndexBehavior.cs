using System.Threading;
using System.Threading.Tasks;
using Azure.Search.Documents;
using Azure.Search.Documents.Models;
using Puls.Cloud.Framework.Application.Contracts;
using Puls.Cloud.Framework.Infrastructure.AzureSearch;
using MediatR;

namespace Puls.Cloud.Framework.Infrastructure.Processing.CommandPipelines;

internal class RemoveFromSearchIndexBehavior<TRequest, TResult> : IPipelineBehavior<TRequest, TResult>
        where TRequest : IRemoveSearchCommand<TResult>
{
    private readonly ISearchIndexClientFactory _searchIndexClientFactory;

    public RemoveFromSearchIndexBehavior(
        ISearchIndexClientFactory searchIndexClientFactory)
    {
        _searchIndexClientFactory = searchIndexClientFactory;
    }

    public async Task<TResult> Handle(TRequest request, RequestHandlerDelegate<TResult> next, CancellationToken cancellationToken)
    {
        var searchModel = await next();

        var action = new IndexDocumentsAction<TResult>(IndexActionType.Delete, searchModel);

        var batch = IndexDocumentsBatch.Create(action);

        var searchIndexClient = _searchIndexClientFactory.Create();

        var searchClient = searchIndexClient.GetSearchClient(request.IndexName);
        await searchClient.IndexDocumentsAsync(
            batch,
            new IndexDocumentsOptions()
            {
                ThrowOnAnyError = false,
            },
            cancellationToken);

        return searchModel;
    }
}