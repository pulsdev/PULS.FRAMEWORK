using System.Linq;
using System.Reflection;
using Puls.Cloud.Framework.Application.Configuration.Commands;
using Puls.Cloud.Framework.Application.Contracts;
using Puls.Cloud.Framework.Application.InternalCommands;
using Puls.Cloud.Framework.Application.Outbox;
using Puls.Cloud.Framework.AzureServiceBus;
using Puls.Cloud.Framework.Cosmos;
using Puls.Cloud.Framework.Cosmos.Abstractions;
using Puls.Cloud.Framework.DirectOperations;
using Puls.Cloud.Framework.DirectOperations.Behaviors;
using Puls.Cloud.Framework.DirectOperations.Configuration;
using Puls.Cloud.Framework.DirectOperations.Contracts;
using Puls.Cloud.Framework.DirectOperations.Repositories;
using Puls.Cloud.Framework.Infrastructure.AzureServiceBus;
using Puls.Cloud.Framework.Infrastructure.Configuration.Processing.InternalCommands;
using Puls.Cloud.Framework.Infrastructure.Configuration.Processing.Outbox;
using Puls.Cloud.Framework.Infrastructure.EventBus;
using Puls.Cloud.Framework.Infrastructure.Processing.CommandPipelines;
using Puls.Cloud.Framework.Infrastructure.Processing.QueryPipelines;
using Puls.Cloud.Framework.ServiceBus;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Puls.Cloud.Framework.Infrastructure.Configuration;

public static class ServiceCollectionExtensions
{    /// <summary>
     /// Registers MediatR services with the .NET Core dependency injection container </summary>
    public static IServiceCollection AddPulsMediator(this IServiceCollection services, IConfiguration configuration, Assembly infrastructureAssembly, Assembly applicationAssembly)
    {
        Assembly[] assemblies = new[]
        {
            infrastructureAssembly,
            applicationAssembly
        };

        RegisterValidations(services, assemblies);
        services.AddSingleton<IServiceModule, ServiceModule>();

        services.AddMediatR(cfg =>
        {
            cfg.RegisterGenericHandlers = true;
            cfg.RegisterServicesFromAssemblies(assemblies);
            cfg.AddOpenBehavior(typeof(DirectCommandLoggingBehavior<,>), ServiceLifetime.Transient);
            cfg.AddOpenBehavior(typeof(DirectCommandTransactionBehavior<,>), ServiceLifetime.Transient);
            cfg.AddOpenBehavior(typeof(DirectCommandDomainEventBehavior<,>), ServiceLifetime.Transient);
            cfg.AddOpenBehavior(typeof(QueryValidationBehavior<,>), ServiceLifetime.Transient);
            cfg.AddOpenBehavior(typeof(CommandValidationBehavior<,>), ServiceLifetime.Transient);
            //cfg.AddOpenBehavior(typeof(NotificationUnitOfWorkBehavior<,>), ServiceLifetime.Transient);
        });

        services.AddScoped<ICosmosEntityChangeTracker, CosmosEntityChangeTracker>();
        services.AddScoped(typeof(ICosmosRepository<,>), typeof(CosmosRepository<,>));

        services.AddScoped<ICommandsScheduler, CommandsScheduler>();
        services.AddSingleton<IContainerFactory, ContainerFactory>();
        // Configure concurrency retry policy
        var retryConfig = new ConcurrencyRetryConfig();
        configuration.GetSection("ConcurrencyRetry").Bind(retryConfig);
        services.AddSingleton(retryConfig);

        services.AddScoped<IDirectUnitOfWork, DirectUnitOfWork>();

        var serviceName = configuration.GetValue<string>("ServiceName") ?? "PulsService";
        var outboxQueueName = $"{serviceName}-outboxmessages".ToLower();
        var internalCommandMessageQueue = $"{serviceName}-internalcommandmessage".ToLower();

        services.AddSingleton(new OutboxConfig { Name = outboxQueueName });
        services.AddSingleton(new InternalCommandConfig { QueueName = internalCommandMessageQueue });

        services.AddSingleton<IQueueClientFactory, QueueClientFactory>();
        services.AddSingleton<ITopicClientFactory, TopicClientFactory>();
        services.AddSingleton<IQueueMessagePublisher, QueueMessagePublisher>();
        services.AddSingleton(new ServiceBusTopicPublisherCompressionOptions
        {
            EnableCompression = false
        });

        services.AddSingleton(new ServiceBusQueuePublisherCompressionOptions
        {
            EnableCompression = false
        });

        services.AddSingleton<IOutboxMessageRepository, OutboxMessageRepository>();
        services.AddSingleton<IInternalMessageRepository, InternalMessageRepository>();
        services.AddSingleton<IOutboxMessageProcessor, OutboxMessageProcessor>();
        services.AddSingleton<IInternalMessageProcessor, InternalMessageProcessor>();

        services.AddSingleton<IEventBus, AzureServiceBusEventBus>();

        services.AddSingleton<IApplicationAssemblyResolver>(new ApplicationAssemblyResolver(applicationAssembly));

        return services;
    }

    public static IServiceCollection AddPulsHostedServices(this IServiceCollection services)
    {
        services.AddHostedService<OutboxMessageBackgroundService>();
        services.AddHostedService<InternalCommandMessageBackgroundService>();
        return services;
    }

    private static void RegisterValidations(IServiceCollection services, params Assembly[] assemblies)
    {
        // Register validators from assemblies manually
        foreach (var assembly in assemblies)
        {
            // Find all validator types in the assembly
            var validatorTypes = assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .Where(t => t.GetInterfaces()
                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IValidator<>)))
                .ToList();

            // Register each validator with its interface
            foreach (var validatorType in validatorTypes)
            {
                var validatorInterface = validatorType.GetInterfaces()
                    .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IValidator<>));
                services.AddTransient(validatorInterface, validatorType);
            }
        }
    }
}