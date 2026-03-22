using Puls.Cloud.Framework.Domain;
using MediatR;

namespace Puls.Cloud.Framework.Application.Configuration.Notifications;

public interface IDomainNotificationHandler<T> : INotificationHandler<T> where T : IDomainEvent
{
}