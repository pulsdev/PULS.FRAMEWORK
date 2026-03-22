using System.Reflection;

namespace Puls.Cloud.Framework.Infrastructure.Configuration;

public class ApplicationAssemblyResolver : IApplicationAssemblyResolver
{
    private readonly Assembly _applicationAssembly;

    public ApplicationAssemblyResolver(Assembly applicationAssembly)
    {
        _applicationAssembly = applicationAssembly;
    }

    public Assembly Resolve() => _applicationAssembly;
}