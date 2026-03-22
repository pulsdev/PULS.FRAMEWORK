using Puls.Cloud.Framework.Domain;
using NetArchTest.Rules;

namespace Puls.ArchRules.Domain
{
    internal class BusinessRuleShouldHaveRulePostfix : ArchRule
    {
        internal override void Check()
        {
            var result = Types.InAssembly(Data.DomainAssembly)
                .That()
                .ImplementInterface(typeof(IBusinessRule))
                .Should().HaveNameEndingWith("Rule")
                .GetResult();

            AssertArchTestResult(result);
        }
    }
}