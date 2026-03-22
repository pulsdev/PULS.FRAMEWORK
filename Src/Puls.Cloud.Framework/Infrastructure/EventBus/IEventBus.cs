using System;
using System.Threading.Tasks;

namespace Puls.Cloud.Framework.Infrastructure.EventBus;

public interface IEventBus : IDisposable
{
    Task Publish<T>(T @event)
        where T : IntegrationEvent;
}
