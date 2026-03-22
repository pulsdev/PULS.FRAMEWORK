using System;
using MediatR;

namespace Puls.Cloud.Framework.Application.Contracts;

public interface ICommand<out TResult> : IRequest, IRequest<TResult>
{
    Guid InternalProcessId { get; }
}

public interface ICommand : ICommand<Unit>
{
}

// TODO: implement the stram command and use stramRequestHandler to return IAsyncEnumerable<TResult>
public interface IStramCommand<out TResult> : IStreamRequest<TResult>
{
}