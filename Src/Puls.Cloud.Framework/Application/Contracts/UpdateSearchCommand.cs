using System;

namespace Puls.Cloud.Framework.Application.Contracts;

public abstract record UpdateSearchCommand<TResult> : IUpdateSearchCommand<TResult>
{
    public Guid InternalProcessId { get; }
    public string IndexName { get; }

    protected UpdateSearchCommand(string indexName)
    {
        IndexName = indexName;
        this.InternalProcessId = Guid.NewGuid();
    }
}