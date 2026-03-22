using System.Threading.Tasks;

namespace Puls.Cloud.Framework.Domain;

public abstract class Entity
{
    protected static async Task CheckRuleAsync(IBusinessRule rule)
    {
        if (await rule.IsBrokenAsync())
        {
            throw new BusinessRuleValidationException(rule);
        }
    }
}