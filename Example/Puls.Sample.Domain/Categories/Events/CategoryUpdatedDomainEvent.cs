using Puls.Cloud.Framework.Domain;

namespace Puls.Sample.Domain.Categories.Events
{
    public record CategoryUpdatedDomainEvent(
        CategoryId CategoryId,
        string Name,
        CategoryTag Tag) : DomainEventBase(CategoryId);
}