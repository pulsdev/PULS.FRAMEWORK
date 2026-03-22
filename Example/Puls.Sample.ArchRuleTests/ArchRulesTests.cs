using System.Reflection;
using Puls.ArchRules;
using Xunit;

namespace Puls.Sample.Tests.ArchRules
{
    public class ArchRulesTests
    {
        [Fact]
        public void Arch_rules_should_be_followed()
        {
            var domainAssembly = Assembly.Load("Puls.Sample.Domain");
            var applicationAssembly = Assembly.Load("Puls.Sample.Application");
            var infrastructureAssembly = Assembly.Load("Puls.Sample.Infrastructure");
            var apiAssembly = Assembly.Load("Puls.Sample.API");
            var integrationEventsAssembly = Assembly.Load("Puls.Sample.IntegrationEvents");

            var engine = new RuleEngine(domainAssembly, applicationAssembly, infrastructureAssembly,
            apiAssembly, integrationEventsAssembly);

            engine.Check();
        }
    }
}