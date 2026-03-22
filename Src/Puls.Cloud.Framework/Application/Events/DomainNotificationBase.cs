using System;
using Puls.Cloud.Framework.Domain;

namespace Puls.Cloud.Framework.Application.Events;

public class DomainNotificationBase<T> : IDomainEventNotification<T> where T : IDomainEvent
{
    public T DomainEvent { get; }

    public Guid Id { get; }

    public DomainNotificationBase(T domainEvent)
    {
        this.Id = Guid.NewGuid();
        this.DomainEvent = domainEvent;
    }
}