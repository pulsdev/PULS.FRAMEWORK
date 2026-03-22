using Puls.ArchRules.Utilities;
using System.Reflection;

namespace Puls.ArchRules.Application.Commands.Handlers
{
    class CommandHandlerShouldNotHaveProperty : ArchRule
    {
        internal override void Check()
        {
            var flags = BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public;
            var result = CommandHandlers
                .ShouldNot()
                .HavePropertyMoreThan(flags, 0);

            AssertArchTestResult(result);
        }
    }
}
