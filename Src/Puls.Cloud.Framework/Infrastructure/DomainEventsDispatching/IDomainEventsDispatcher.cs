using System.Collections.Generic;
using System.Threading.Tasks;

namespace Puls.Cloud.Framework.Infrastructure.DomainEventsDispatching;

internal interface IDomainEventsDispatcher
{
    Task<IEnumerable<OutboxMessageRefrences>> DispatchEventsAsync();
}
