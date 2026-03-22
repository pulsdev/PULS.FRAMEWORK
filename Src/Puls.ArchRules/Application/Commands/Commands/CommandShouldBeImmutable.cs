using Puls.ArchRules.Utilities;

namespace Puls.ArchRules.Application.Commands.Commands
{
    class CommandShouldBeImmutable : ArchRule
    {
        internal override void Check()
        {
            var result = Commands
                .Should()
                .BeInitOnly();

            AssertArchTestResult(result);
        }
    }
}