using Puls.Sample.Domain.Commons;
using Puls.Cloud.Framework.Domain;

namespace Puls.Sample.Domain.UserAccounts.DomainEvents
{
    public record UserAccountCreatedDomainEvent(
        UserAccountId UserAccountId,
        TenantId TenantId,
        string FirstName,
        string LastName,
        string EmailAddress) : DomainEventBase(UserAccountId);
}