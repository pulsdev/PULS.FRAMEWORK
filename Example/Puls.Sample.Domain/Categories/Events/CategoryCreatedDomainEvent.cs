using Puls.Cloud.Framework.Domain;

namespace Puls.Sample.Domain.Categories.Events
{
    public record CategoryCreatedDomainEvent(
        CategoryId CategoryId,
        string PartitionKey,
        string Name,
        string? Description) : DomainEventBase(CategoryId);
}