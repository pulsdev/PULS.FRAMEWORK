using Puls.Cloud.Framework.DirectOperations;
using Puls.Cloud.Framework.Domain;
using NetArchTest.Rules;

namespace Puls.ArchRules.Domain
{
    internal class Onlyaggregatescouldbemarkedasauditable : ArchRule
    {
        internal override void Check()
        {
            var result = Types.InAssembly(Data.DomainAssembly)
                .That()
                .ImplementInterface(typeof(IAuditable))
                .Should()
                .Inherit(typeof(CosmosEntity));

            AssertArchTestResult(result);
        }
    }
}