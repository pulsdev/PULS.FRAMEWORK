using Puls.Sample.Domain.Commons;
using Puls.Cloud.Framework.Domain;

namespace Puls.Sample.Domain.UserAccounts.BusinessRules
{
    public class UserAccountShouldBeUniqueRule : IBusinessRule
    {
        private readonly bool _isUnique;

        public UserAccountShouldBeUniqueRule(bool isUnique)
        {
            _isUnique = isUnique;
        }

        public Task<bool> IsBrokenAsync()
        {
            return Task.FromResult(!_isUnique);
        }

        public string Message => ErrorList.UserAccountAlreadyExist;
    }
}