using Puls.Cloud.Framework.Infrastructure.AzureSearch;
using NetArchTest.Rules;

namespace Puls.ArchRules.Application.Commands.Search
{
    internal class SearchIndexCreators_should_not_be_public : ArchRule
    {
        internal override void Check()
        {
            var result = Types.InAssembly(Data.ApplicationAssembly)
                .That()
                .ImplementInterface(typeof(ISearchIndexCreator<,>))
                .ShouldNot()
                .BePublic();

            AssertArchTestResult(result);
        }
    }
}