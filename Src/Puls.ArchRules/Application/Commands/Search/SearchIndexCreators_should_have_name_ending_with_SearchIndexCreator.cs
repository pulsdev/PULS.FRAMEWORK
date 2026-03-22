using Puls.Cloud.Framework.Infrastructure.AzureSearch;
using NetArchTest.Rules;

namespace Puls.ArchRules.Application.Commands.Search
{
    internal class SearchIndexCreators_should_have_name_ending_with_SearchIndexCreator : ArchRule
    {
        internal override void Check()
        {
            var result = Types.InAssembly(Data.ApplicationAssembly)
                .That()
                .ImplementInterface(typeof(ISearchIndexCreator<,>))
                .Should()
                .HaveNameEndingWith("SearchIndexCreator");

            AssertArchTestResult(result);
        }
    }
}