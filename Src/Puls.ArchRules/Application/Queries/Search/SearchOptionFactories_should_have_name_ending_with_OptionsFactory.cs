using Puls.Cloud.Framework.Infrastructure.AzureSearch;
using NetArchTest.Rules;

namespace Puls.ArchRules.Application.Queries.Search
{
    internal class SearchOptionFactories_should_have_name_ending_with_OptionsFactory : ArchRule
    {
        internal override void Check()
        {
            var result = Types.InAssembly(Data.ApplicationAssembly)
                .That()
                .ImplementInterface(typeof(ISearchOptionFactory<,>))
                .Should()
                .HaveNameEndingWith("OptionsFactory")
                .GetResult();

            AssertArchTestResult(result);
        }
    }
}