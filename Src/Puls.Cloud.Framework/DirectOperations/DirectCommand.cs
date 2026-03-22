using System;
using Puls.Cloud.Framework.DirectOperations.Contracts;

namespace Puls.Cloud.Framework.DirectOperations;

public abstract record DirectCommand : IDirectCommand
{
    public Guid InternalProcessId { get; }

    protected DirectCommand()
    {
        this.InternalProcessId = Guid.NewGuid();
    }
}

public abstract record DirectCommand<TResult> : IDirectCommand<TResult>
{
    public Guid InternalProcessId { get; }

    protected DirectCommand()
    {
        this.InternalProcessId = Guid.NewGuid();
    }
}