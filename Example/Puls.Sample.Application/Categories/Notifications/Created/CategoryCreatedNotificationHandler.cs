using Puls.Sample.Application.Categories.Commands.Update;
using Puls.Sample.Domain.Categories.Events;
using Puls.Sample.IntegrationEvents.Categories;
using Puls.Cloud.Framework.Application.Configuration.Commands;
using Puls.Cloud.Framework.Application.Configuration.Notifications;
using Puls.Cloud.Framework.Infrastructure.EventBus;

namespace Puls.Sample.Application.Categories.Notifications.Created
{
    public class CategoryCreatedNotificationHandler : IDomainNotificationHandler<CategoryCreatedDomainEvent>
    {
        private readonly ICommandsScheduler _commandsScheduler;
        private readonly IEventBus _eventBus;

        public CategoryCreatedNotificationHandler(ICommandsScheduler commandsScheduler, IEventBus eventBus)
        {
            _commandsScheduler = commandsScheduler;
            _eventBus = eventBus;
        }

        public async Task Handle(CategoryCreatedDomainEvent domainEvent, CancellationToken cancellationToken)
        {
            await _eventBus.Publish(new CategorycreatedIntegrationEvent(
                    domainEvent.CategoryId,
                    domainEvent.Name));
        }
    }
}