using System;

namespace Puls.Cloud.Framework.Application.Contracts;

public abstract record Command : ICommand
{
    public Guid InternalProcessId { get; }

    protected Command()
    {
        this.InternalProcessId = Guid.NewGuid();
    }
}

public abstract record Command<TResult> : ICommand<TResult>
{
    public Guid InternalProcessId { get; }

    protected Command()
    {
        this.InternalProcessId = Guid.NewGuid();
    }
}