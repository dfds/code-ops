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

            services.AddTransient(p =>
            {
                var logger = p.GetService<ILogger<IProducer<string, IIntegrationEvent>>>();
                var producerOptions = p.GetService<IOptions<KafkaOptions>>();
                var producerBuilder = new ProducerBuilder<string, IIntegrationEvent>(producerOptions.Value.Configuration);
                var producer = producerBuilder.SetErrorHandler((_, e) => logger.LogError($"Error: {e?.Reason}", e))
                                            .SetStatisticsHandler((_, json) => logger.LogDebug($"Statistics: {json}"))
                                            .SetValueSerializer(new DefaultValueSerializer<IIntegrationEvent>())
                                            .Build();

                return producer;
            });
        }
    }
}
