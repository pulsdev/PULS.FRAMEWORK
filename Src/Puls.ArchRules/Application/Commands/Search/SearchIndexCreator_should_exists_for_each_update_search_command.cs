using Puls.Cloud.Framework.Application.Contracts;
using Puls.Cloud.Framework.Infrastructure.AzureSearch;
using NetArchTest.Rules;
using System.Linq;

namespace Puls.ArchRules.Application.Commands.Search
{
    internal class SearchIndexCreator_should_exists_for_each_update_search_command : ArchRule
    {
        internal override void Check()
        {
            var allSearchCommands = Types.InAssembly(Data.ApplicationAssembly)
                .That()
                .Inherit(typeof(UpdateSearchCommand<>))
                .GetTypes();
            var handlers = Types.InAssembly(Data.ApplicationAssembly)
                .That()
                .ImplementInterface(typeof(ISearchIndexCreator<,>))
                .GetTypes()
                .ToArray();

            var commandsWhichHaveHandlers = handlers
                .Select(x => x.GetInterfaces()
                    .First(x => x.Name.Contains("ISearchIndexCreator"))
                    .GenericTypeArguments.First())
                .ToList();

            AssertFailingTypes(allSearchCommands.Except(commandsWhichHaveHandlers));
        }
    }
}