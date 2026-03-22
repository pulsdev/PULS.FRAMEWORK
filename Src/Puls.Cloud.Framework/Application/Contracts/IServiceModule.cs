using Puls.Cloud.Framework.DirectOperations.Contracts;
using System.Threading.Tasks;

namespace Puls.Cloud.Framework.Application.Contracts;

public interface IServiceModule
{
    Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);

    Task ExecuteCommandAsync(IDirectCommand command);

    Task<TResult> ExecuteCommandAsync<TResult>(IDirectCommand<TResult> command);
}