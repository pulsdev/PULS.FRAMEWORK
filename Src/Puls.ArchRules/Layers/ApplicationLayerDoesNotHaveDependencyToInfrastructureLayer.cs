using NetArchTest.Rules;

namespace Puls.ArchRules.Layers
{
    class ApplicationLayerDoesNotHaveDependencyToInfrastructureLayer : ArchRule
    {
        internal override void Check()
        {
            var result = Types.InAssembly(Data.ApplicationAssembly)
                .Should()
                .NotHaveDependencyOn(Data.InfrastructureAssembly.GetName().Name)
                .GetResult();

            AssertArchTestResult(result);
        }
    }
}
