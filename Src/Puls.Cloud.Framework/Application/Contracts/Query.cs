using System;

namespace Puls.Cloud.Framework.Application.Contracts;

public abstract record Query<TResult> : Query, IQuery<TResult>
{
    public Guid InternalProcessId { get; }

    protected Query()
    {
        InternalProcessId = Guid.NewGuid();
    }
}

public abstract record Query
{
    internal Query()
    {
    }
}

public abstract record SearchQuery
{
    internal SearchQuery()
    {
    }
}

public abstract record DownloadableQuery
{
    internal DownloadableQuery()
    {
    }
}