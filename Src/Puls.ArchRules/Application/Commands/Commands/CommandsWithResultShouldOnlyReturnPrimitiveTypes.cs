using System.Linq;
using Puls.ArchRules.Utilities;

namespace Puls.ArchRules.Application.Commands.Commands
{
    class CommandsWithResultShouldOnlyReturnPrimitiveTypes : ArchRule
    {
        internal override void Check()
        {
            var commandResults = CommandResults.ToArray();

            AssertFailingTypes(commandResults
                .Where(x => !x.IsPrimitive()));
        }
    }
}
