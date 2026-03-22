using MediatR;

namespace Puls.Cloud.Framework.Application.Events;

public interface IDomainNotificationRequest : IRequest, IRequest<Unit>
{
}