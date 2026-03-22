using Puls.Cloud.Framework.Infrastructure.EventBus;
using NetArchTest.Rules;

namespace Puls.ArchRules.IntegrationEvents
{
    internal class IntegrationEvents_should_be_in_integrationEvents_assembly : ArchRule
    {
        internal override void Check()
        {
            var types = Types.InAssemblies(new[] { Data.DomainAssembly, Data.ApplicationAssembly, Data.InfrastructureAssembly })
                .That()
                .Inherit(typeof(IntegrationEvent))
                .GetTypes();

            AssertFailingTypes(types);
        }
    }
}