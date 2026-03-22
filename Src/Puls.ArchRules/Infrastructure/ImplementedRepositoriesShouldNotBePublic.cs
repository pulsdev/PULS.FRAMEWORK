using Puls.Cloud.Framework.DirectOperations.Repositories;
using NetArchTest.Rules;

namespace Puls.ArchRules.Infrastructure
{
    internal class ImplementedRepositoriesShouldNotBePublic : ArchRule
    {
        internal override void Check()
        {
            var result = Types.InAssembly(Data.InfrastructureAssembly)
                .That()
                .ImplementInterface(typeof(ICosmosRepository<,>))
                .ShouldNot()
                .BePublic()
                .GetResult();

            AssertArchTestResult(result);
        }
    }
}