using Puls.Cloud.Framework.Application.Contracts;
using Puls.Cloud.Framework.Infrastructure.AzureSearch;
using NetArchTest.Rules;
using System.Linq;

namespace Puls.ArchRules.Application.Queries.Search
{
    internal class QueryFactory_should_exists_for_each_search_query : ArchRule
    {
        internal override void Check()
        {
            var allSearchQueries = Types.InAssembly(Data.ApplicationAssembly)
                .That()
                .Inherit(typeof(SearchQuery<>))
                .GetTypes();
            var handlers = Types.InAssembly(Data.ApplicationAssembly)
                .That()
                .ImplementInterface(typeof(IQueryFactory<>))
                .GetTypes()
                .ToArray();

            var queriesWhichHaveHandlers = handlers
                .Select(x => x.GetInterfaces()
                    .First(x => x.Name.Contains("IQueryFactory"))
                    .GenericTypeArguments.First())
                .ToList();

            AssertFailingTypes(allSearchQueries.Except(queriesWhichHaveHandlers));
        }
    }
}