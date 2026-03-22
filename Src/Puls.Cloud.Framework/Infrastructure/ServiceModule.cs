using System.Threading.Tasks;
using Puls.Cloud.Framework.Application.Contracts;
using Puls.Cloud.Framework.DirectOperations.Contracts;
using Puls.Cloud.Framework.Infrastructure.Configuration;
using Puls.Cloud.Framework.Infrastructure.Configuration.Processing;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Puls.Cloud.Framework.Infrastructure;

public class ServiceModule : IServiceModule
{
    public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
    {
        using var scope = ServiceCompositionRoot.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

        return await mediator.Send(query);
    }

    public async Task<TResult> ExecuteCommandAsync<TResult>(IDirectCommand<TResult> command)
    {
        return await CommandsExecutor.Execute(command);
    }

    public async Task ExecuteCommandAsync(IDirectCommand command)
    {
        await CommandsExecutor.Execute(command);
    }
}