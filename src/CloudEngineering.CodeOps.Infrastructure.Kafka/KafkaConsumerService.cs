using AutoMapper;
using CloudEngineering.CodeOps.Abstractions.Facade;
using CloudEngineering.CodeOps.Abstractions.Strategies;
using CloudEngineering.CodeOps.Infrastructure.Kafka.Strategies;
using Confluent.Kafka;
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
        private readonly IStrategy<ConsumeResult<string, string>> _consumptionStrategy;
        protected readonly IOptions<KafkaOptions> _options;

        public KafkaConsumerService(ILogger<KafkaConsumerService> logger, IOptions<KafkaOptions> options, IMapper mapper, IFacade applicationFacade) : this(logger, options, new DefaultConsumptionStrategy(mapper, applicationFacade))
        {
        }

        public KafkaConsumerService(ILogger<KafkaConsumerService> logger, IOptions<KafkaOptions> options, IStrategy<ConsumeResult<string, string>> consumptionStrategy)
        {
            _logger = logger ?? throw new ArgumentException(null, nameof(logger));
            _options = options ?? throw new ArgumentException(null, nameof(options));
            _consumptionStrategy = consumptionStrategy ?? throw new ArgumentException(null, nameof(consumptionStrategy));
        }

        protected async override Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var config = new ConsumerConfig(_options.Value.Configuration)
            {
                EnablePartitionEof = _options.Value.EnablePartitionEof,
                StatisticsIntervalMs = _options.Value.StatisticsIntervalMs
            };

            using var consumer = new ConsumerBuilder<string, string>(config)
            .SetErrorHandler((_, e) => _logger.LogError($"Error: {e.Reason}", e))
            .SetStatisticsHandler((_, json) => _logger.LogDebug($"Statistics: {json}"))
            .SetPartitionsAssignedHandler((c, partitions) =>
            {
                _logger.LogInformation($"Assigned partitions: [{string.Join(", ", partitions)}]");
            })
            .SetPartitionsRevokedHandler((c, partitions) =>
            {
                _logger.LogInformation($"Revoking assignment: [{string.Join(", ", partitions)}]");
            })
            .Build();

            foreach (var topic in _options.Value.Topics)
            {
                consumer.Subscribe(topic);
            }

            try
            {
                while (true)
                {
                    try
                    {
                        var consumeResult = consumer.Consume(cancellationToken);

                        if (consumeResult.IsPartitionEOF)
                        {
                            _logger.LogInformation($"Reached end of topic {consumeResult.Topic}, partition {consumeResult.Partition}, offset {consumeResult.Offset}.");

                            continue;
                        }

                        _logger.LogInformation($"Received message at {consumeResult.TopicPartitionOffset}: {consumeResult.Message.Value}");

                        await _consumptionStrategy.Apply(consumeResult, cancellationToken);


                        if (consumeResult.Offset % _options.Value.CommitPeriod == 0)
                        {
                            try
                            {
                                consumer.Commit(consumeResult);
                            }
                            catch (KafkaException e)
                            {
                                _logger.LogError($"Commit error: {e.Error.Reason}", e);
                            }
                        }
                    }
                    catch (ConsumeException e)
                    {
                        _logger.LogError($"Consume error: {e.Error.Reason}", e);
                    }
                }
            }
            catch (OperationCanceledException e)
            {
                _logger.LogInformation("Closing consumer.", e);

                consumer.Close();
            }

            return;
        }
    }
}
