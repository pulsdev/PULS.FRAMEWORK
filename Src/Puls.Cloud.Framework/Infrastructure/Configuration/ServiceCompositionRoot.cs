using System;
using Microsoft.Extensions.DependencyInjection;

namespace Puls.Cloud.Framework.Infrastructure.Configuration;

public static class ServiceCompositionRoot
{
    private static IServiceProvider _serviceProvider;

    public static void SetServiceProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public static IServiceScope CreateScope()
    {
        return _serviceProvider.CreateScope();
    }

    public static IServiceProvider ServiceProvider => _serviceProvider;
}