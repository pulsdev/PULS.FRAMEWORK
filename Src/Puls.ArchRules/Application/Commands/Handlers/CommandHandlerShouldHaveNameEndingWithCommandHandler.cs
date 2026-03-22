using Puls.Cloud.Framework.Application.Configuration.Commands;
using NetArchTest.Rules;

namespace Puls.ArchRules.Application.Commands.Handlers
{
    internal class CommandHandlerShouldHaveNameEndingWithCommandHandler : ArchRule
    {
        internal override void Check()
        {
            var result = Types.InAssembly(Data.ApplicationAssembly)
                .That()
                .ImplementInterface(typeof(ICommandHandler<>)).Or()
                .ImplementInterface(typeof(ICommandHandler<,>))
                .And()
                .DoNotHaveNameMatching(".*Decorator.*").Should()
                .HaveNameEndingWith("CommandHandler");

            AssertArchTestResult(result);
        }
    }
}