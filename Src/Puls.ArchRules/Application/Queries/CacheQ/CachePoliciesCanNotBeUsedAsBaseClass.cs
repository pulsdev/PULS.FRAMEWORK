using CacheQ;
using Puls.ArchRules.Utilities;
using NetArchTest.Rules;

namespace Puls.ArchRules.Application.Queries.CacheQ
{
    class CachePoliciesCanNotBeUsedAsBaseClass : ArchRule
    {
        internal override void Check()
        {
            var result = Types.InAssembly(Data.ApplicationAssembly)
                .That()
                .ImplementInterface(typeof(ICachePolicy<>))
                .ShouldNot()
                .UsedAsBaseClass(AllTypes);

            AssertArchTestResult(result);
        }
    }
}
