using Amatsucozy.PMS.Shared.Helpers.MessageQueues.Configurations;
using Amatsucozy.PMS.Shared.Helpers.MessageQueues.Constants;
using Azure;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Amatsucozy.PMS.Shared.Helpers.MessageQueues;

public static class MessageQueueHelper
{
    public static void AddMessageQueue(
        this IServiceCollection serviceCollection,
        IConfiguration configuration,
        Type consumersContainingAssemblyType)
    {
        var queueOptions = configuration
            .GetSection(nameof(QueueOptions))
            .Get<QueueOptions>();

        if (queueOptions is null)
        {
            throw new Exception("Queue options is not configured");
        }

        if (!Uri.TryCreate(queueOptions.Host, UriKind.Absolute, out var hostUri))
        {
            throw new Exception("Queue host is not in a correct format");
        }

        switch (hostUri!.Scheme)
        {
            case QueueProviderSchemes.RabbitMq:
            {
                AddRabbitMq(serviceCollection, queueOptions, hostUri, consumersContainingAssemblyType);
                break;
            }
            case QueueProviderSchemes.AzureServiceBus:
            {
                AddServiceBus(serviceCollection, queueOptions, hostUri, consumersContainingAssemblyType);
                break;
            }
            default:
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }

    private static void AddRabbitMq(
        this IServiceCollection serviceCollection,
        QueueOptions queueOptions,
        Uri hostUri,
        Type consumersContainingAssemblyType)
    {
        serviceCollection.AddMassTransit(configurator =>
        {
            configurator.UsingRabbitMq((context, factoryConfigurator) =>
            {
                factoryConfigurator.Host(hostUri, hostConfigurator =>
                {
                    hostConfigurator.Username(queueOptions.Username);
                    hostConfigurator.Password(queueOptions.Password);
                });

                factoryConfigurator.ConfigureEndpoints(context);
                factoryConfigurator.ReceiveEndpoint(queueOptions.QueueName, endpointConfigurator =>
                {
                    endpointConfigurator.DeadLetterExchange = $"{queueOptions.QueueName}_dead_letter";
                });
            });

            configurator.AddConsumers(consumersContainingAssemblyType.Assembly);
        });
    }

    private static void AddServiceBus(
        this IServiceCollection serviceCollection,
        QueueOptions queueOptions,
        Uri hostUri,
        Type consumersContainingAssemblyType)
    {
        serviceCollection.AddMassTransit(configurator =>
        {
            configurator.UsingAzureServiceBus((context, factoryConfigurator) =>
            {
                factoryConfigurator.Host(hostUri, hostConfigurator =>
                {
                    hostConfigurator.NamedKeyCredential = new AzureNamedKeyCredential
                    (
                        queueOptions.Username,
                        queueOptions.Password
                    );
                });
                
                factoryConfigurator.ConfigureEndpoints(context);
                factoryConfigurator.ReceiveEndpoint(queueOptions.QueueName, endpointConfigurator =>
                {
                    endpointConfigurator.EnableDeadLetteringOnMessageExpiration = true;
                });
            });

            configurator.AddConsumers(consumersContainingAssemblyType.Assembly);
        });
    }
}