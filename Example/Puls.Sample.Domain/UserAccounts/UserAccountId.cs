using Puls.Cloud.Framework.Domain;

namespace Puls.Sample.Domain.UserAccounts
{
    public class UserAccountId : TypedId<Guid>
    {
        public UserAccountId(Guid value) : base(value)
        {
        }
    }
}