using Puls.Cloud.Framework.Application.Contracts;
using MediatR;

namespace Puls.Cloud.Framework.Application.Configuration.Commands;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand> where TCommand : ICommand
{
}

public interface ICommandHandler<in TCommand, TResult> :
    IRequestHandler<TCommand, TResult> where TCommand : ICommand<TResult>
{
}