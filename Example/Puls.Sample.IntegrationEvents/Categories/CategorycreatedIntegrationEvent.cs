using Puls.Sample.Domain.Categories;
using Puls.Cloud.Framework.Infrastructure.EventBus;

namespace Puls.Sample.IntegrationEvents.Categories
{
    public record CategorycreatedIntegrationEvent(
    CategoryId CategoryId,
    string Name) : IntegrationEvent(CategoryId, "CategoryCreatedEvent");
}