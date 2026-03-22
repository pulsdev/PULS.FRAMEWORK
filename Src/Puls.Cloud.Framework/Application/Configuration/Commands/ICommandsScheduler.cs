using System.Threading.Tasks;
using Puls.Cloud.Framework.Application.Contracts;
using Puls.Cloud.Framework.DirectOperations.Contracts;

namespace Puls.Cloud.Framework.Application.Configuration.Commands;

public interface ICommandsScheduler
{
    Task EnqueueAsync(IDirectCommand command);

    Task EnqueueAsync<TResult>(IDirectCommand<TResult> command);

    Task EnqueueAsync<TResult>(IUpdateSearchCommand<TResult> command);

    Task EnqueueAsync<TResult>(IRemoveSearchCommand<TResult> command);

    Task EnqueueAsync(IDirectCommand command, string? sessionId);

    Task EnqueueAsync<TResult>(IDirectCommand<TResult> command, string? sessionId);

    Task EnqueueAsync<TResult>(IUpdateSearchCommand<TResult> command, string? sessionId);

    Task EnqueueAsync<TResult>(IRemoveSearchCommand<TResult> command, string? sessionId);
}