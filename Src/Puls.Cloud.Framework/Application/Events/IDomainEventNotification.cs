using Puls.Cloud.Framework.Domain;

namespace Puls.Cloud.Framework.Application.Events;

public interface IDomainEventNotification<out TEvent> : IDomainNotificationRequest
    where TEvent : IDomainEvent
{
    TEvent DomainEvent { get; }
}