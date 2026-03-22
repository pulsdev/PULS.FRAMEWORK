using Puls.ArchRules.Utilities;
using Puls.Cloud.Framework.Application.Contracts;
using NetArchTest.Rules;

namespace Puls.ArchRules.Application.Queries.Queries
{
    internal class QueryShouldBeImmutable : ArchRule
    {
        internal override void Check()
        {
            var result = Types.InAssembly(Data.ApplicationAssembly)
                .That()
                .Inherit(typeof(Query<>)).Or()
                .ImplementInterface(typeof(IQuery<>))
                .Should()
                .BeInitOnly();

            AssertArchTestResult(result);
        }
    }
}