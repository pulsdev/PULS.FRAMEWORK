using Puls.Cloud.Framework.Application.Configuration.Commands;
using Puls.Cloud.Framework.Application.Configuration.Queries;
using NetArchTest.Rules;

namespace Puls.ArchRules.Application.Commands.Handlers
{
    internal class CommandAndQueryHandlersShouldNotBePublic : ArchRule
    {
        internal override void Check()
        {
            var types = Types.InAssembly(Data.ApplicationAssembly)
                .That()
                .ImplementInterface(typeof(IQueryHandler<,>))
                .Or()
                .ImplementInterface(typeof(ICommandHandler<,>))
                .Or()
                .ImplementInterface(typeof(ICommandHandler<>))
                .Should().NotBePublic().GetResult().FailingTypes;

            AssertFailingTypes(types);
        }
    }
}