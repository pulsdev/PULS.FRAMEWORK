using Puls.Cloud.Framework.Application.Configuration.Queries;
using NetArchTest.Rules;

namespace Puls.ArchRules.Application.Queries.Handlers
{
    internal class QueryHandlerShouldHaveNameEndingWithQueryHandler : ArchRule
    {
        internal override void Check()
        {
            var result = Types.InAssembly(Data.ApplicationAssembly)
               .That()
               .ImplementInterface(typeof(IQueryHandler<,>))
               .Should()
               .HaveNameEndingWith("QueryHandler")
               .GetResult();

            AssertArchTestResult(result);
        }
    }
}