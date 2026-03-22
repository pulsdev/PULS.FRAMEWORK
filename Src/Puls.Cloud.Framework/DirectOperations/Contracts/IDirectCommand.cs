using MediatR;
using System;

namespace Puls.Cloud.Framework.DirectOperations.Contracts
{
    public interface IDirectCommand<out TResult> : IRequest, IRequest<TResult>
    {
        Guid InternalProcessId { get; }
    }

    public interface IDirectCommand : IDirectCommand<Unit>
    {
    }
}