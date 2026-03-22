using System.Collections.Generic;
using Puls.Cloud.Framework.Domain;

namespace Puls.Cloud.Framework.Infrastructure.DomainEventsDispatching;

internal interface IDomainEventsAccessor
{
    List<IDomainEvent> GetAllDomainEvents();

    void ClearAllDomainEvents();
}
