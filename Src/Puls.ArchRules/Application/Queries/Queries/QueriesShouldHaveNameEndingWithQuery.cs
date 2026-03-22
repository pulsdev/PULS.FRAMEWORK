using Puls.Cloud.Framework.Application.Contracts;
using NetArchTest.Rules;

namespace Puls.ArchRules.Application.Queries.Queries
{
    internal class QueriesShouldHaveNameEndingWithQuery : ArchRule
    {
        internal override void Check()
        {
            var result = Types.InAssembly(Data.ApplicationAssembly)
               .That()
               .Inherit(typeof(Query<>))
               .Should()
               .HaveNameEndingWith("Query")
               .GetResult();

            AssertArchTestResult(result);
        }
    }
}