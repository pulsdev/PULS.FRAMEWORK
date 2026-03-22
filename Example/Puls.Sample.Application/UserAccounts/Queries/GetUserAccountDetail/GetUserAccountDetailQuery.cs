using Puls.Cloud.Framework.Application.Contracts;

namespace Puls.Sample.Application.UserAccounts.Queries.GetUserAccountDetail
{
    public record GetUserAccountDetailQuery(Guid UserId) : Query<UserAccountDetailQueryDto>();
}