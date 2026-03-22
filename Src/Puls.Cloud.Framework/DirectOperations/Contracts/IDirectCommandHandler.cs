using MediatR;

namespace Puls.Cloud.Framework.DirectOperations.Contracts;

public interface IDirectCommandHandler<in TCommand> : IRequestHandler<TCommand> where TCommand : IDirectCommand
{
}

public interface IDirectCommandHandler<in TCommand, TResult> :
    IRequestHandler<TCommand, TResult> where TCommand : IDirectCommand<TResult>
{
}