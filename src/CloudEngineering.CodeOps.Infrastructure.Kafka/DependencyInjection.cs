using CloudEngineering.CodeOps.Abstractions.Events;
using CloudEngineering.CodeOps.Infrastructure.Kafka.Serialization;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CloudEngineering.CodeOps.Infrastructure.Kafka
{
    public static class DependencyInjection
    {
        public static void AddKafka(this IServiceCollection services, IConfiguration configuration)
        {
            //Framework dependencies
            services.AddLogging();

            //Package dependencies
            services.Configure<KafkaOptions>(configuration.GetSection(KafkaOptions.Kafka));
            services.AddKafkaProducer();
            services.AddKafkaConsumer();
        }

        private static void AddKafkaProducer(this IServiceCollection services)
        {
            services.AddTransient(p =>
            {
                var logger = p.GetService<ILogger<IProducer<string, IIntegrationEvent>>>();
                var kafkaOptions = p.GetService<IOptions<KafkaOptions>>();
                var producerBuilder = new ProducerBuilder<string, IIntegrationEvent>(kafkaOptions.Value.Configuration);
                var producer = producerBuilder.SetErrorHandler((_, e) => logger.LogError($"Error: {e?.Reason}", e))
                                            .SetStatisticsHandler((_, json) => logger.LogDebug($"Statistics: {json}"))
                                            .SetValueSerializer(new DefaultValueSerializer<IIntegrationEvent>())
                                            .Build();

                return producer;
            });
        }

        private static void AddKafkaConsumer(this IServiceCollection services)
        {
            services.AddTransient(p =>
            {
                var logger = p.GetService<ILogger<KafkaConsumerService>>();
                var kafkaOptions = p.GetService<IOptions<KafkaOptions>>();
                var consumerConfig = new ConsumerConfig(kafkaOptions.Value.Configuration)
                {
                    EnablePartitionEof = kafkaOptions.Value.EnablePartitionEof,
                    StatisticsIntervalMs = kafkaOptions.Value.StatisticsIntervalMs
                };
                var consumerBuilder = new ConsumerBuilder<string, string>(consumerConfig);
                var consumer = consumerBuilder
                                .SetErrorHandler((_, e) => logger?.LogError($"Error: {e.Reason}", e))
                                .SetStatisticsHandler((_, json) => logger?.LogDebug($"Statistics: {json}"))
                                .SetPartitionsAssignedHandler((c, partitions) =>
                                {
                                    logger?.LogInformation($"Assigned partitions: [{string.Join(", ", partitions)}]");
                                })
                                .SetPartitionsRevokedHandler((c, partitions) =>
                                {
                                    logger?.LogInformation($"Revoking assignment: [{string.Join(", ", partitions)}]");
                                })
                                .Build();

                return consumer;
            });
        }
    }
}
