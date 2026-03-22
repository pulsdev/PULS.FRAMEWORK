using Puls.Sample.Domain.Commons;
using Puls.Sample.Domain.UserAccounts;
using Puls.Cloud.Framework.DirectOperations;

namespace Puls.Sample.Application.UserAccounts.Commands.Create
{
    public record CreateUserAccountCommand(
        UserAccountId UserAccountId,
        TenantId TenantId,
        string FirstName,
        string LastName,
        string EmailAddress) : DirectCommand<Guid>;
}