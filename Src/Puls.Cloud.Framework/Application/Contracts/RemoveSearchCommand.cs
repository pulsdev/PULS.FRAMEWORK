using System;

namespace Puls.Cloud.Framework.Application.Contracts;

public abstract record RemoveSearchCommand<TResult> : IRemoveSearchCommand<TResult>
{
    public Guid InternalProcessId { get; }
    public string IndexName { get; }

    protected RemoveSearchCommand(string indexName)
    {
        IndexName = indexName;
        this.InternalProcessId = Guid.NewGuid();
    }
}