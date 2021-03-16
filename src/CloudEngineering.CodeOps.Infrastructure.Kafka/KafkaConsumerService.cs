using CloudEngineering.CodeOps.Abstractions.Events;
using CloudEngineering.CodeOps.Abstractions.Strategies;
using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.Kafka
{
    public class KafkaConsumerService : BackgroundService
    {
        protected readonly ILogger<KafkaConsumerService> _logger;
        protected readonly IServiceScopeFactory _scopeFactory;
        protected readonly IOptions<KafkaOptions> _options;

        public KafkaConsumerService(IOptions<KafkaOptions> options, IServiceScopeFactory scopeFactory, ILogger<KafkaConsumerService> logger = default)
        {
            _options = options ?? throw new ArgumentException(null, nameof(options));
            _scopeFactory = scopeFactory ?? throw new ArgumentException(null, nameof(scopeFactory));
            _logger = logger;
        }

        protected async override Task ExecuteAsync(CancellationToken cancellationToken)
        {
            using var scope = _scopeFactory.CreateScope();
            var consumer = scope.ServiceProvider.GetRequiredService<IConsumer<string, string>>();

            consumer.Subscribe(_options.Value.Topics);

            try
            {
                while (true)
                {
                    try
                    {
                        var consumeResult = consumer.Consume(cancellationToken);

                        if (consumeResult.IsPartitionEOF)
                        {
                            _logger?.LogInformation($"Reached end of topic {consumeResult.Topic}, partition {consumeResult.Partition}, offset {consumeResult.Offset}.");

                            continue;
                        }

                        _logger?.LogInformation($"Received message at {consumeResult.TopicPartitionOffset}: {consumeResult.Message.Value}");

                        var consumptionStrategy = scope.ServiceProvider.GetRequiredService<IStrategy<ConsumeResult<string, string>>>();

                        await consumptionStrategy.Apply(consumeResult, cancellationToken);

                        if (consumeResult.Offset % _options.Value.CommitPeriod == 0)
                        {
                            try
                            {
                                consumer.Commit(consumeResult);
                            }
                            catch (KafkaException e)
                            {
                                _logger?.LogError($"Commit error: {e.Error.Reason}", e);
                            }
                        }
                    }
                    catch (ConsumeException e)
                    {
                        _logger?.LogError($"Consume error: {e.Error.Reason}", e);
                    }
                }
            }
            catch (OperationCanceledException e)
            {
                _logger?.LogInformation("Closing consumer.", e);

                consumer.Close();
            }

            return;
        }
    }
}
